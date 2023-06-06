 using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class CalculationsService : ICalculationsRepository
	{

		DestinationService desService;
		ReviewService revService;
		public Review[] Reviews;
		public CalculationsService() { }
		public CalculationsService(DestinationService des, ReviewService rev)
		{
			this.desService = des;
			this.revService = rev;
		}
		private ReviewDTO ToDTO(Review review)
		{
			var r = new ReviewDTO()
			{
				UserId = review.UserId,
				DestinationId = review.DestinationId,
				ReviewTxt = review.ReviewTxt,
				Rating = review.Rating,
			};
			return r;
		}
		private Review FromDTO(ReviewDTO reviewDTO)
		{
			var r = new Review()
			{
				UserId = reviewDTO.UserId,
				DestinationId = reviewDTO.DestinationId,
				ReviewTxt = reviewDTO.ReviewTxt,
				Rating = reviewDTO.Rating,
			};
			return r;
		}

		public double CalculateAverage(List<double> ratingList)
		{
			double sum = 0;
			var count = 0;
			foreach (var num in ratingList)
			{
				sum += num;
				count++;

			}
			var average = sum / count;

			var roundedResult = Math.Round(average, 2, MidpointRounding.AwayFromZero);
			var AvgRating = roundedResult;
			return AvgRating;
		}
		public int CalculateWeight(int userId, List<Review> re)
		{
			int result = 0;
            foreach (var r in re)
			{
				result = re.Count(r => r.UserId == userId);
			}
			return result;
		}
		public Review[] UserWithMostReviewWeight(int desId)
		{
            double sum = 0;
            int count = 0;

            var reviews = revService.GetReviews().ToList();

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
			

            reviews = reviews.OrderByDescending(u => CalculateWeight(u.UserId, reviews)).ToList();

            return reviews.OrderByDescending(u => CalculateWeight(u.UserId, reviews)).ToArray();

            //Reviews = revService.GetReviews();
            //Reviews = Reviews.OrderByDescending(r => CalculateWeight(r.UserId)).ToArray();
            //return Reviews;
        }

        public Destination[] BestRatedDestinations() //sugestions by rating
		{
			var destinations = desService.GetAllDestinations().ToList();
            List<double> ratings = new List<double>();
            foreach (var d in destinations)
			{
				ratings.Add(d.AvgRating);
			}
			var avgBestRating = CalculateAverage(ratings);

			int countList = destinations.Count;
			List<Destination> bestRateddesti = new List<Destination>();
			for (int i = countList - 1; i >= 0 ; i--)
			{
                if (destinations[i].AvgRating > avgBestRating)
                {
                    bestRateddesti.Add(destinations[i]);
                }
				countList--;
            }
			bestRateddesti = bestRateddesti.OrderByDescending(d => d.AvgRating).ToList();
			return bestRateddesti.ToArray();
		}
	}
}
