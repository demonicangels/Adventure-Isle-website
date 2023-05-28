using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class RecommendationsTestPageModel : PageModel
    {
        AlgorithmService algorithm;
        DestinationService desService;
        public Destination[] Recommendations { get; set; }
        public RecommendationsTestPageModel(AlgorithmService algorithmService, DestinationService destinationService) 
        {
            this.algorithm = algorithmService;
            desService = destinationService;
        }

        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var userDes = desService.AllDesOfUser((int)userId).ToList();
            Recommendations = new Destination[userDes.Count];
			if (userId != null && userDes.Count > 0)
            {
                Recommendations = algorithm.Recommendations((int)userId);
            }
        }
    }
}
