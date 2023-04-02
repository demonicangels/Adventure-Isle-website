using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AdventureAisleCore.Pages
{
    
    public class IndexModel : PageModel
    {
        
        [BindProperty]
        public string? Search { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("search", Search);
                return RedirectToPage("/DestinationResult");
            }
        }
    }
}
