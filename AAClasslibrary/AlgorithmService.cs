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
	public class AlgorithmService : IAlgorithmRepository
	{

		DestinationService desService;
		ReviewService revService;
		public Review[] Reviews;
		public AlgorithmService() { }
		public AlgorithmService(DestinationService des, ReviewService rev)
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
		public int CalculateWeight(int userId)
		{
			int result = Reviews.Count(r => r.UserId == userId);
			return result;
		}
		public Review[] UserWithMostReviewWeight()
		{
			Reviews = revService.GetReviews();
			Reviews = Reviews.OrderByDescending(r => CalculateWeight(r.UserId)).ToArray();
			return Reviews;
		}
		public Destination[] Recommendations(int userId)
		{
			var userDes = desService.AllDesOfUser(userId).ToList();
			var allDestinations = desService.GetAllDestinations();

			foreach (var des in userDes)
			{
				var index = userDes.IndexOf(des);
				var fulldestination = allDestinations[index];
				if (userDes[index].Id == fulldestination.Id)
				{
					userDes[index].Name = fulldestination.Name;
					userDes[index].Country = fulldestination.Country;
					userDes[index].Currency = fulldestination.Currency;
					userDes[index].BriefDescription = fulldestination.BriefDescription;
					userDes[index].Climate = fulldestination.Climate;
					userDes[index].AvgRating = fulldestination.AvgRating;
					userDes[index].ImgURL = fulldestination.ImgURL;
				}
			}

			if (userDes.Count > 1)
			{
				var duplicates = userDes.GroupBy(c => c.Climate)
					.Where(d => d.Count() > 1)
					.Select(d => new { Name = d.Key, Count = d.Count() })
					.ToList();

				var mostVisitedC = duplicates.OrderByDescending(c => c.Count).FirstOrDefault();

				var recommendations = allDestinations.Where(d => !userDes.Any(des => des.Name == d.Name) && d.Climate == mostVisitedC.Name);
				return recommendations.ToArray();
			}
			else if (userDes.Count == 1)
			{
				var singleDestinationClimate = userDes.Where(d => d.UsrId == userId).FirstOrDefault();
				var recommendations = allDestinations.Where(d => !userDes.Any(des => d.Name == des.Name) && d.Climate == singleDestinationClimate.Climate).ToList();
				return recommendations.ToArray();
			}
			else
			{
				return userDes.ToArray();
			}
		}
		public Destination[] BestRatedDestinations()
		{
			var destinations = desService.GetAllDestinations().ToList();
			Destination bestRated = destinations[0];
			List<Destination> bestRateddesti = new List<Destination>();
			for (int i = 0; i < destinations.Count; i++)
			{

				if (destinations[0].AvgRating > 0 && destinations[i].AvgRating >= 4)
				{
					if (destinations[i].AvgRating >= bestRated.AvgRating)
					{
						bestRated = destinations[i];
					}
					bestRateddesti.Add(bestRated);
					destinations.Remove(bestRated);
					i--;
					

					
				}
				else if (destinations[i].AvgRating == 0 || destinations[i].AvgRating < 4)
				{
					destinations.Remove(destinations[i]);
					i--;
				}
				else
				{
					continue;
				}
			}
			bestRateddesti = bestRateddesti.OrderByDescending(d => d.AvgRating).ToList();
			return bestRateddesti.ToArray();
		}
	}
}
