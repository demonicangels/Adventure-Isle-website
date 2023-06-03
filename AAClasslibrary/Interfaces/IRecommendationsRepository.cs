using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRecommendationsRepository
    {
        Destination[] RecommendationsByClimateUsers(int userId);
        Destination[] BestRatedDestinations();
        Destination[] RecommendationByClimateVisitors(string wantedClimate);
    }
}
