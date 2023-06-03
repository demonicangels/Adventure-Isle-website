using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace AdventureAisleCore.Pages
{
    public class RecommendationsTestPageModel : PageModel
    {

        DestinationService desService;
        RecommendationService recommendationService;
        IRecommendationsRepository recommendationsRepository;
        public Destination[] Recommendations { get; set; }

        [BindProperty]
        public string WantedClimate { get; set; }

        [BindProperty]
        public int? UserId { get; set; }

        public Dictionary<string, Func<IRecommendationsRepository, Destination[]>> iDictionary = new Dictionary<string, Func<IRecommendationsRepository, Destination[]>>();

        public RecommendationsTestPageModel(DestinationService destinationService, RecommendationService recommendation, IRecommendationsRepository re) 
        {
            this.desService = destinationService;
            this.recommendationService = recommendation;
            this.recommendationsRepository = re;
            //iList.Add(new RecommendationService());
        }

        public void OnGet()
        {
            UserId = HttpContext.Session.GetInt32("userId");

            if (UserId != null)
            {
                var userDes = desService.AllDesOfUser((int)UserId).ToList();
                Recommendations = recommendationService.RecommendationsByClimateUsers((int)UserId);
            }
            Recommendations = desService.GetAllDestinations();
        }
        public void OnPost(string option)
        {
            UserId = HttpContext.Session.GetInt32("userId");
            iDictionary.Add("Climate", recommendationsRepository => UserId != null
                                                                   ? recommendationService.RecommendationsByClimateUsers((int)UserId)
                                                                   : recommendationService.RecommendationByClimateVisitors(WantedClimate));
          
            iDictionary.Add("Rating", recommendationsRepository => recommendationService.BestRatedDestinations());


            foreach (KeyValuePair<string, Func<IRecommendationsRepository, Destination[]>> action in iDictionary)
            {
                Recommendations = action.Key == option ? action.Value.Invoke(recommendationService) : null;

                var shouldbreak = option == action.Key ? true : false;

                if (shouldbreak)
                {
                    break;
                }
            }
        }
    }
}
