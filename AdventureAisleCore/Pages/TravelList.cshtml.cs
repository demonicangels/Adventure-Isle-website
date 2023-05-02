using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    [Authorize(Roles = "User")]
    public class TravelListModel : PageModel
    {
       
        public List<string> Necessities { get; set; } = new List<string>();
        public IActionResult OnGet()
        {
            if (User.IsInRole("User"))
            {
                return Page();
            }
            return Unauthorized();
        }
        public IActionResult OnPost(List<string>item)
        {
            foreach(string s in item)
            {
                Necessities.Add(s);
            }
            return Page();
        }
    }
}
