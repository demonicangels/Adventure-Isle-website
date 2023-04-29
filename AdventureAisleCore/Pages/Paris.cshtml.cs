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
            var id = (int)HttpContext.Session.GetInt32("userId");
            User = userService.GetUserById(id);

            Desi = destinationService.GetDestinationByName(Destination);
            

            Review.UserEmail = User.Email;
            Review.DestinationName = Destination;
            reviews.Insert(Review);
            Reviews = reviews.GetReviews(Destination);

            return Page();
        }
    }
}
