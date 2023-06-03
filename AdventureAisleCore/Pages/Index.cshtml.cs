using BusinessLogic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace AdventureAisleCore.Pages
{
    
    public class IndexModel : PageModel
    {
        CalculationsService algorithm;
        DestinationService desService;
        RecommendationService recommendationService;

        [BindProperty]
        public string Search { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? Logout { get; set; }
        public Destination[]? Recommendations { get; set; }
        public int? UsrId { get; set; }
        public IndexModel(CalculationsService algorithmService, DestinationService destinationService, RecommendationService recommendationService)
        {
            this.algorithm = algorithmService;
            this.desService = destinationService;
            this.recommendationService = recommendationService;
        }

        public async void OnGet()
        {
            UsrId = HttpContext.Session.GetInt32("userId");

            if (Logout != null)
            {
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["Logout"] = "Successful logout";
                Recommendations = algorithm.BestRatedDestinations();
            }
            else if (UsrId != null)
            {
                var userDes = desService.AllDesOfUser((int)UsrId).ToList();
                Recommendations = new Destination[userDes.Count];

                if (UsrId != null && userDes.Count > 0)
                {
                    Recommendations = recommendationService.RecommendationsByClimateUsers((int)UsrId);
                }
            }
            else
            {
                Recommendations = algorithm.BestRatedDestinations();
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
