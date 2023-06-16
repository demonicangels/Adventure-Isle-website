using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL;

namespace FactoryServices
{
	public class setRepositories : IRepositoryFactory
	{
		public IDestinationRepository SetDestinationRepository()
		{
			IDestinationRepository destinationRepository = new DestinationRepository();
			return destinationRepository;
		}

		public IReviewRepository SetReviewRepository()
		{
			IReviewRepository reviewRepository = new ReviewRepository();
			return reviewRepository;
		}

		public ITravelListRepository SetTravelListRepository()
		{
			ITravelListRepository travelListRepository = new TravelListRepository();
			return travelListRepository;
		}

		public IUserRepository SetUserRepository()
		{
			IUserRepository userRepository = new UserRepository();
			return userRepository;
		}

		public ICalculationsRepository SetCalculationsRepository()
		{
			ICalculationsRepository calculationsRepository = new Calculations();
			return calculationsRepository;
		}
	}
}
