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
			UserService userService = new UserService();
			userService.Init(repoFactory.SetUserRepository());
			return userService;
		}
		public static DestinationService destinationServiceObject()
		{
			DestinationService destinationService = new DestinationService();
			return destinationService;
		}
		public static ReviewService reviewServiceObject()
		{
			ReviewService revService = new ReviewService();
			return revService;
		}
		public static TravelListService travelListServiceObject()
		{
			TravelListService listService = new TravelListService();
			return listService;
		}
	}
}