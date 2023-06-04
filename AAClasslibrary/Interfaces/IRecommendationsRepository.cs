using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRecommendationsRepository
    {
        Destination[] RecommendationsByClimateUsers(int userId, DestinationService desService);
        Destination[] BestRatedDestinations(DestinationService desService);
        Destination[] RecommendationByClimateVisitors(string wantedClimate, DestinationService desService);
        Destination[] RecommendationByWantedRating(double wantedRating, DestinationService desService);
    }
}
