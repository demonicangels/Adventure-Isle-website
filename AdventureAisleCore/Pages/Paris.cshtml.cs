using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    //@if()
    //{
    //
    //                < form method = "post" >
    //
    //                    < textarea ></ textarea >
    //
    //                </ form >
    //
    //            }

    public class ParisModel : PageModel
    {
        [BindProperty]
        public Review Review { get; set; }

        public List<Review> Reviews { get; set; }

        public User User { get; set; }
        public void OnGet()
        {
            HttpContext.Session.GetInt32("userId");
            User = UserService.GetUserById(User.Id);
        }
    }
}
