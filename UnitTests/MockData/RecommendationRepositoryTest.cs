using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    internal class RecommendationRepositoryTest : IRecommendationsRepository
    {
        List<Destination> destinationList = new List<Destination>()
        {
           new Destination(0, "Rome", "Italy", "euro", "", "Mostly humid subtropical", 5, "", 0, 0),
           new Destination(0, "Paris", "France", "euro", "", "Continental", 4.33, "", 0, 0),
           new Destination(0, "Stockholm", "Sweden", "euro", "", "Continental", 3, "", 0, 0),

        };
        List<Destination> usrDes = new List<Destination>()
        {
            new Destination(0, "Stockholm", "Sweden", "euro", "", "Continental", 3, "", 0, 0),
        };
        public Destination[] BestRatedDestinations(DestinationService desService)
        {
            var bestRated = destinationList.Where(d => d.AvgRating > 4.11).ToArray();
            return bestRated;
        }

        public Destination[] RecommendationByClimateVisitors(string wantedClimate, DestinationService desService)
        {
            var rec = destinationList.Where(d => d.Climate.Contains(wantedClimate)).ToArray();
            return rec;
        }

        public Destination[] RecommendationByWantedRating(double wantedRating, DestinationService desService)
        {
            var rec = destinationList.Where(d => d.AvgRating == wantedRating).ToArray();
            return rec;
        }

        public Destination[] RecommendationsByClimateUsers(int userId, DestinationService desService)
        {
            Destination[] desis = new Destination[10];
            foreach(var ud in usrDes)
            {
                desis = destinationList.Where(d => d.Climate == ud.Climate && !usrDes.Any(desi => desi.Name == d.Name)).ToArray();
            }
            return desis;
        }
    }
}
