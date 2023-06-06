using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
	public class RecommendationRepoTest : IRecommendationsRepository
	{
		public Destination[] BestRatedDestinations(DestinationService desService)
		{
			throw new NotImplementedException();
		}

		public Destination[] RecommendationByClimateVisitors(string wantedClimate, DestinationService desService)
		{
			throw new NotImplementedException();
		}

		public Destination[] RecommendationByWantedRating(double wantedRating, DestinationService desService)
		{
			throw new NotImplementedException();
		}

		public Destination[] RecommendationsByClimateUsers(int userId, DestinationService desService)
		{
			throw new NotImplementedException();
		}
	}
}
