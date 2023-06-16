using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class CalculationService
	{
		ICalculationsRepository calculations;
		DestinationService desService;
		ReviewService revService;
		public CalculationService(ICalculationsRepository calculations, DestinationService d, ReviewService r)
		{
			this.calculations = calculations;
			this.desService = d;
			this.revService = r;
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

		public double CalculateAverageWeightDestination(int desId)
		{
			var reviews = revService.GetReviews().ToList();
			var result = calculations.CalculateAverageWeightDestination(desId,reviews);
			return result;
		}
		public Review[] UserWithMostReviewWeight()
		{
			var reviews = revService.GetReviews().ToList();
			var result = calculations.UserWithMostReviewWeight(reviews);
			return result;
		}

	}
}
