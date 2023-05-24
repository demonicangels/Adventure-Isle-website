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
        AlgorithmService algorithmService;

        
        
        [BindProperty(SupportsGet = true)]
        public string Destination { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        [BindProperty]
        public string CheckedValue { get; set; }

        [BindProperty]
        public DestinationStatus? DesStatus { get; set; }

        public Review[] DesReviews { get; set; }

		public Review[] Reviews { get; set; }

		public User User { get; set; }

        public List<Destination> Desi { get; set; } = new List<Destination>();

        public ParisModel(UserService u, DestinationService d, ReviewService r, AlgorithmService a)
        {
            userService = u;
            destinationService = d;
            reviews = r;
            algorithmService = a;
		}
		public void OnGet()
        {
            Reviews = algorithmService.UserWithMostReviewWeight();
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
			Reviews = algorithmService.UserWithMostReviewWeight();

			if (Review.ReviewTxt != null)
            {
                int amount;
                int.TryParse(CheckedValue, out amount);
                Review.UserId = User.Id;
                Review.DestinationId = Desi.FirstOrDefault().Id;
                Review.Rating = amount;
                reviews.Insert(Review);
                Reviews = reviews.GetReviewsByDesId(Desi.FirstOrDefault().Id);
                
                DesReviews = Reviews.Where(d => d.DestinationId == Desi.FirstOrDefault().Id).ToArray();

                foreach (var d in Desi)
                {
                    foreach (var rev in Reviews)
                    {
                        d.AddRating(rev.Rating);
                    }
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


            
			if (Desi[0].DesStatus != null && DesStatus != null)
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
