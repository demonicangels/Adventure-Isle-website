using BusinessLogic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;

namespace AdventureAisleCore.Pages
{
    
    public class IndexModel : PageModel
    {
        
        DestinationService desService;
        RecommendationsService recommendationService;

        [BindProperty]
        public string Search { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? Logout { get; set; }
        public Destination[]? Recommendations { get; set; }
        public int? UsrId { get; set; }
        public IndexModel(DestinationService destinationService, RecommendationsService recommendationService)
        {
            this.desService = destinationService;
            this.recommendationService = recommendationService;
        }

        public async void OnGet()
        {
            UsrId = HttpContext.Session.GetInt32("userId") ?? 0;
			recommendationService.InitializeDictionary(0, "", "");

			if (Logout != null)
            {
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["Logout"] = "Successful logout";
				Recommendations = recommendationService.Recommendations("");
            }
            else if (UsrId != 0 && UsrId != null)
            {
                var userDes = desService.AllDesOfUser((int)UsrId).ToList();
                Recommendations = new Destination[userDes.Count];

                if(userDes.Count > 0)
                {
					recommendationService.InitializeDictionary((int)UsrId, "", "");
					Recommendations = recommendationService.Recommendations("");
                }
            }
            Recommendations = recommendationService.Recommendations("");
         
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
