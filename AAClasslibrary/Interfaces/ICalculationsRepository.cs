using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface ICalculationsRepository
	{
		double CalculateAverage(List<double> ratingList);
		int CalculateUserWeight(int userId, List<Review> re);
		double CalculateAverageWeightDestination(int desId, List<Review> reviews);
		Review[] UserWithMostReviewWeight(List<Review> reviews);
    }
}
