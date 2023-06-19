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
        RecommendationsService recommendationService;
        IRecommendationsRepository recommendationsRepository;
        public Destination[] Recommendations { get; set; }

        [BindProperty]
        public string WantedClimate { get; set; }

        [BindProperty]
        public int? UserId { get; set; }


        public RecommendationsTestPageModel(DestinationService destinationService, RecommendationsService recommendation, IRecommendationsRepository re) 
        {
            this.desService = destinationService;
            this.recommendationService = recommendation;
            this.recommendationsRepository = re;
            //iList.Add(new RecommendationService());
        }

        public void OnGet()
        {
            UserId = HttpContext.Session.GetInt32("userId") ?? 0;

            if (UserId != 0 || UserId != null)
            {
                var userDes = desService.AllDesOfUser((int)UserId).ToList();
                Recommendations =  userDes == null ? desService.GetAllDestinations().OrderBy(c => c.Climate).ToArray() : recommendationsRepository.RecommendationsByClimateUsers((int)UserId, desService);
            }
            Recommendations = desService.GetAllDestinations();
        }
        public void OnPost(string option)
        {
            try
            {
                UserId = HttpContext.Session.GetInt32("userId");
                recommendationService.InitializeDictionary(UserId == null ? 0 : UserId.Value, WantedClimate);
                Recommendations = recommendationService.Recommendations(option);
            }
            catch(InvalidInformationException i)
            {
                TempData["exMessage"] = i.Message;
            }
        }
    }
}
