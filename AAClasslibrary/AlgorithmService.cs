using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class AlgorithmService : IAlgorithmRepository
	{
		
		private static IDestinationRepository _destinationRepository;
		ReviewService rev;
		public Review[] Reviews;
		public AlgorithmService() { }
		public AlgorithmService(IDestinationRepository destinationRepository, ReviewService rev)
		{
			_destinationRepository = destinationRepository;
			this.rev = rev;
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
		public int CalculateWeight(int userId)
		{
			int result = Reviews.Count(r => r.UserId == userId);
			return result;
		}
		public Review[] UserWithMostReviewWeight()
		{
			Reviews = rev.GetReviews();
			Reviews = Reviews.OrderByDescending(r => CalculateWeight(r.UserId)).ToArray();
			return Reviews;
		}
	}
}
