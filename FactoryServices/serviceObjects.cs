using BusinessLogic;
using BusinessLogic.Interfaces;

namespace Factory
{
	public class serviceObjects
	{
		private static IRepositoryFactory repoFactory;

		public serviceObjects(IRepositoryFactory factory) 
		{
			repoFactory = factory;
		}
		public static UserService userServiceObject()
		{
			UserService userService = new UserService(repoFactory.SetUserRepository());
			return userService;
		}
		public static DestinationService destinationServiceObject()
		{
			DestinationService destinationService = new DestinationService(repoFactory.SetDestinationRepository());
			return destinationService;
		}
		public static ReviewService reviewServiceObject()
		{
			ReviewService revService = new ReviewService(repoFactory.SetReviewRepository());
			return revService;
		}
		public static TravelListService travelListServiceObject()
		{
			TravelListService listService = new TravelListService(repoFactory.SetTravelListRepository());
			return listService;
		}
		public static CalculationsRepo calculationsServiceObject()
		{
			CalculationsRepo calculationsService = new CalculationsRepo(destinationServiceObject(), reviewServiceObject());
			return calculationsService;
		}
	}
}