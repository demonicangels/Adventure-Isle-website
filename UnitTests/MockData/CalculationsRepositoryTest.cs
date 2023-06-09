using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    internal class CalculationsRepositoryTest : ICalculationsRepository
    {
        public Destination[] BestRatedDestinations(List<Destination> allDestinations)
        {
            throw new NotImplementedException();
        }

        public double CalculateAverage(List<double> ratingList)
        {
            throw new NotImplementedException();
        }

        public double CalculateAverageWeightDestination(int desId, List<Review> reviews)
        {
            double sum = 0;
            int count = 0;

            var userRatingCount = reviews
                .GroupBy(u => u.UserId)
                .ToDictionary(g => g.Key, g => g.Count());

            var userRatingForThisDes = reviews
                .Where(x => x.DestinationId == desId)
                .GroupBy(u => u.UserId)
                .ToDictionary(g => g.Key, g => g.FirstOrDefault().Rating);

            Dictionary<int, double> totalSumofRatingofUser = new Dictionary<int, double>();

            foreach (KeyValuePair<int, double> entry in userRatingForThisDes)
            {
                if (userRatingCount.ContainsKey(entry.Key))
                {
                    sum += entry.Value * userRatingCount[entry.Key];
                    count += userRatingCount[entry.Key];
                }
            }

            var avgWeight = sum / count;

            var average = Math.Round(avgWeight, 2, MidpointRounding.AwayFromZero);

            return average;
        }

        public int CalculateUserWeight(int userId, List<Review> re)
        {
            int result = 0;
            foreach (var r in re)
            {
                result = re.Count(r => r.UserId == userId);
            }
            return result;
        }

        public Review[] UserWithMostReviewWeight(List<Review> reviews)
        {
            var result = reviews.OrderByDescending(u => CalculateUserWeight(u.UserId, reviews)).ToArray();
            return result;
        }
    }
}
