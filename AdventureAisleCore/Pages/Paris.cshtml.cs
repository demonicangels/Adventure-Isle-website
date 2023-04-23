using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class ParisModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Destination { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        public Review[] Reviews { get; set; }

        public User User { get; set; }

        public void OnGet()
        {
            if(HttpContext.Session.GetInt32("userId") != null)
            {
                var id = (int)HttpContext.Session.GetInt32("userId");
                User = UserService.GetUserById(id);
				Reviews = ReviewService.GetReviews(Destination);
			}
            else
            {
                Reviews = ReviewService.GetReviews(Destination);
            }
        }
        public IActionResult OnPost()
        {
            var id = (int)HttpContext.Session.GetInt32("userId");
            User = UserService.GetUserById(id);
            

            Review.UserEmail = User.Email;
            Review.DestinationName = Destination;
            ReviewService.Insert(Review);
            Reviews = ReviewService.GetReviews(Destination);

            return Page();
        }
    }
}
