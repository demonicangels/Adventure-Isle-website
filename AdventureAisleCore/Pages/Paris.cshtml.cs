using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;

namespace AdventureAisleCore.Pages
{
    public class ParisModel : PageModel
    {
        ReviewService reviews;
        UserService userService;
        DestinationService destinationService;

        [BindProperty(SupportsGet = true)]
        public string Destination { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        [BindProperty]
        public string CheckedValue { get; set; }

        [BindProperty]
        public DestinationStatus DesStatus { get; set; }

        public Review[] DesReviews { get; set; }

		public Review[] Reviews { get; set; }

		public User User { get; set; }

        public List<Destination> Desi { get; set; } = new List<Destination>();

        public ParisModel(UserService u, DestinationService d, ReviewService r)
        {
            userService = u;
            destinationService = d;
            reviews = r;
		}

        public int UserWithMostReviewWeight(int userId)
        {
            int result = Reviews.Count(r => r.UserId == userId);
            return result;
        }
		public void OnGet()
        {
			Reviews = reviews.GetReviews();
			Reviews = Reviews.OrderByDescending(r => UserWithMostReviewWeight(r.UserId)).ToArray();
            var userWithMostWeight = Reviews[0].UserId;

			if (HttpContext.Session.GetInt32("userId") != null)
            {
                var id = (int)HttpContext.Session.GetInt32("userId");
                User = userService.GetUserById(id);
				Desi = destinationService.GetDestinationByName(Destination);
                Desi[0] = destinationService.GetDestinationWithStatus(Desi.FirstOrDefault(), id);
                DesReviews = Reviews.Where(d => d.DestinationId == Desi.FirstOrDefault().Id).ToArray();
			}
            else
            {
				Desi = destinationService.GetDestinationByName(Destination);
                DesReviews = Reviews.Where(d => d.DestinationId == Desi.FirstOrDefault().Id).ToArray();   
            }
        }
        public IActionResult OnPost()
        {
			var usrid = (int)HttpContext.Session.GetInt32("userId");
            User = userService.GetUserById(usrid);

            Desi = destinationService.GetDestinationByName(Destination);
			Desi[0] = destinationService.GetDestinationWithStatus(Desi.FirstOrDefault(), usrid);
            Reviews = reviews.GetReviews();
            Reviews = Reviews.OrderByDescending(r => UserWithMostReviewWeight(r.UserId)).ToArray();


            if (Review.ReviewTxt != null)
            {
                int amount;
                int.TryParse(CheckedValue, out amount);
                Review.UserId = User.Id;
                Review.DestinationId = Desi.FirstOrDefault().Id;
                Review.Rating = amount;
                reviews.Insert(Review);
                
                DesReviews = Reviews.Where(d => d.DestinationId == Desi.FirstOrDefault().Id).ToArray();

                foreach (var d in Desi)
                {
                    foreach (var rev in Reviews)
                    {
                        d.AddRating(rev.Rating);
                    }
                    d.AddRating(Convert.ToDouble(CheckedValue));
                    d.AvgRating = d.CalculateAverage();
                    if (Convert.ToDouble(CheckedValue) > 0)
                    {
                        destinationService.UpdateDestination(d);
                    }
                }
            }
            else
            {
                DesReviews = Reviews.Where(d => d.DestinationId == Desi.FirstOrDefault().Id).ToArray();
            }



			if (Desi.FirstOrDefault().DesStatus != null && Desi.FirstOrDefault().DesStatus != (int)DesStatus)
			{
                Desi.FirstOrDefault().DesStatus = (int)DesStatus;
                Desi[0] = destinationService.UpdateStatusByUserIdAndDesId(Desi.FirstOrDefault(), usrid);
			}
			else if (DesStatus == DestinationStatus.BeenTo)
            {
                Desi.FirstOrDefault().DesStatus = (int)DestinationStatus.BeenTo;
                destinationService.SetDestinationStatus(Desi.FirstOrDefault(), usrid);
			}
            else if(DesStatus == DestinationStatus.GoingTo)
            {
				Desi.FirstOrDefault().DesStatus = (int)DestinationStatus.GoingTo;
				destinationService.SetDestinationStatus(Desi.FirstOrDefault(), usrid);
			}

            

            return Page();
        }
    }
}
