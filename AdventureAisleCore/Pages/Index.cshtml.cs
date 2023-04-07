using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace AdventureAisleCore.Pages
{
    
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Search { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("search", Search);
                return RedirectToPage("/DestinationResult");
            }
            else
            {
                return Page();
            }
        }
    }
}
