using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace AdventureAisleCore.Pages
{
    
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Search { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? Logout { get; set; }

        public async void OnGet()
        {
            if(Logout != null)
            {
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
				TempData["Logout"] = "Successful logout";
			}
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("search", Search);
                return RedirectToPage("/Destinations");
            }
            else
            {
                return Page();
            }
        }
    }
}
