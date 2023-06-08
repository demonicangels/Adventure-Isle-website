using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
	public interface IRepositoryFactory
	{
		IUserRepository SetUserRepository();
		IDestinationRepository SetDestinationRepository();
		IReviewRepository SetReviewRepository();
		ITravelListRepository SetTravelListRepository();
		ICalculationsRepository SetCalculationsRepository();
	}
}
