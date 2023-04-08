using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    [Authorize(Roles = "User")]
    public class TravelListModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.IsInRole("User"))
            {
                return Page();
            }
            return Unauthorized();
        }
    }
}
