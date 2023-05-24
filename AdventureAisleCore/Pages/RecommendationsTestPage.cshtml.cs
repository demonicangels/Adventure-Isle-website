using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdventureAisleCore.Pages
{
    public class RecommendationsTestPageModel : PageModel
    {
        AlgorithmService algorithm;
        public Destination[] Recommendations { get; set; }
        public RecommendationsTestPageModel(AlgorithmService algorithmService) 
        {
            this.algorithm = algorithmService;
        }

        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if(userId != null)
            {
                Recommendations = algorithm.Recommendations((int)userId);
            }
        }
    }
}
