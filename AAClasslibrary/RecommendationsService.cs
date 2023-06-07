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
        // you test the service method and mock the interface for unit testing 
        private IRecommendationsRepository _recommendationsRepository;
        private DestinationService desService;
        public Dictionary<string, Func<IRecommendationsRepository, Destination[]>> iDictionary = new Dictionary<string, Func<IRecommendationsRepository, Destination[]>>();
		List<Destination> recommendations = new List<Destination>();

		public RecommendationsService(IRecommendationsRepository recs, DestinationService d)
        {
            _recommendationsRepository = recs;
            desService = d;
		}
		public void InitializeDictionary(int? userId, string wantedValue, string option) 
		{
			iDictionary.Clear();

			iDictionary.Add("Climate", repository => userId != 0 && userId != null && string.IsNullOrEmpty(wantedValue)
													   ? repository.RecommendationsByClimateUsers((int)userId, desService)
													   : !string.IsNullOrEmpty(wantedValue) ? repository.RecommendationByClimateVisitors(wantedValue, desService)
													   : repository.BestRatedDestinations(desService));

			iDictionary.Add("Rating", repository => wantedValue != null ? repository.RecommendationByWantedRating(double.Parse(wantedValue), desService) : _recommendationsRepository.BestRatedDestinations(desService));

			iDictionary.Add("Start", repository => userId != 0 && userId != null ? repository.RecommendationsByClimateUsers((int)userId, desService) : repository.BestRatedDestinations(desService));

		}
        public Destination[] Recommendations(string option)
        {
            if (iDictionary.ContainsKey(option))
            {
                recommendations = iDictionary[option].Invoke(_recommendationsRepository).ToList();
            }
			else
			{
				recommendations = iDictionary["Start"].Invoke(_recommendationsRepository).ToList();
			}

			//foreach (KeyValuePair<string, Func<IRecommendationsRepository, Destination[]>> action in iDictionary)
			//{
			//    recommendations = action.Key == option || option == string.Empty ? action.Value.Invoke(_recommendationsRepository).ToList() : null;
			//
			//    var shouldbreak = option == action.Key || option == string.Empty ? true : false;
			//
			//    if (shouldbreak)
			//    {
			//        break;
			//    }
			//}
			return recommendations.ToArray();
        }
        
    }
}
