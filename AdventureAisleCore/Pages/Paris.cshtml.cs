using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Factory;

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

        public Review[] Reviews { get; set; }

        public User User { get; set; }

        public List<Destination> Desi { get; set; } = new List<Destination>();

        public void OnGet()
        {
            reviews = serviceObjects.reviewServiceObject();
			userService = serviceObjects.userServiceObject();
			destinationService = serviceObjects.destinationServiceObject();

			if (HttpContext.Session.GetInt32("userId") != null)
            {
                var id = (int)HttpContext.Session.GetInt32("userId");
                User = userService.GetUserById(id);
				Reviews = reviews.GetReviews(Destination);
				Desi = destinationService.GetDestinationByName(Destination);
			}
            else
            {
                Reviews = reviews.GetReviews(Destination);
				Desi = destinationService.GetDestinationByName(Destination);
			}
        }
        public IActionResult OnPost()
        {
			reviews = serviceObjects.reviewServiceObject();
			userService = serviceObjects.userServiceObject();
			destinationService = serviceObjects.destinationServiceObject();

			var id = (int)HttpContext.Session.GetInt32("userId");
            User = userService.GetUserById(id);

            Desi = destinationService.GetDestinationByName(Destination);
            

            if(Review.ReviewTxt != null)
            {
                Review.UserEmail = User.Email;
                Review.DestinationName = Destination;
                Review.Rating = int.Parse(CheckedValue);
				reviews.Insert(Review);
                Reviews = reviews.GetReviews(Destination);
            }
            else
            {
                Reviews = reviews.GetReviews(Destination);
            }

            foreach(var d in Desi)
            {
                foreach(var rev in Reviews)
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
            return Page();
        }
    }
}
