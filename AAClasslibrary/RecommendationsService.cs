using BusinessLogic.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RecommendationsService
    {
        private IRecommendationsRepository _recommendationsRepository;
        private DestinationService desService;
        public Dictionary<string, Func<IRecommendationsRepository, Destination[]>> iDictionary = new Dictionary<string, Func<IRecommendationsRepository, Destination[]>>();
        public RecommendationsService(IRecommendationsRepository recs, DestinationService d)
        {
            _recommendationsRepository = recs;
            desService = d;
        }

        public Destination[] Recommendations(int? userId,string wantedValue, string option)
        {
            List<Destination> recommendations = new List<Destination>();
            iDictionary.Add("Climate", recommendationsRepository => userId != 0 && userId != null && string.IsNullOrEmpty(wantedValue) 
                                                                   ? _recommendationsRepository.RecommendationsByClimateUsers((int)userId, desService)
                                                                   : !string.IsNullOrEmpty(wantedValue) ? _recommendationsRepository.RecommendationByClimateVisitors(wantedValue, desService) : _recommendationsRepository.BestRatedDestinations(desService));

            iDictionary.Add("Rating", recommendationsRepository => wantedValue != null ? _recommendationsRepository.RecommendationByWantedRating(double.Parse(wantedValue), desService) : _recommendationsRepository.BestRatedDestinations(desService));


            foreach (KeyValuePair<string, Func<IRecommendationsRepository, Destination[]>> action in iDictionary)
            {
                recommendations = action.Key == option || option == string.Empty ? action.Value.Invoke(_recommendationsRepository).ToList() : null;

                var shouldbreak = option == action.Key || option == string.Empty ? true : false;

                if (shouldbreak)
                {
                    break;
                }
            }
            return recommendations.ToArray();
        }
        
    }
}
