using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IAlgorithmRepository
	{
		double CalculateAverage(List<double> ratingList);
		int CalculateWeight(int userId);
		Review[] UserWithMostReviewWeight();

	}
}
