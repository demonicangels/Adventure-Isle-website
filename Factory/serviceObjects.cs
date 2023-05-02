using BusinessLogic;
using BusinessLogic.Interfaces;

namespace Factory
{
	public class serviceObjects
	{
		static IUserRepository usrRepo;
		static IDestinationRepository desRepo;
		static IReviewRepository revRepo;
		static ITravelListRepository travListRepo;

		public serviceObjects(IUserRepository usr, IDestinationRepository des, IReviewRepository rev, ITravelListRepository trav) 
		{
			usrRepo = usr;
			desRepo = des;
			revRepo = rev;
			travListRepo = trav;
		}
		public static UserService userServiceObject()
		{
			UserService userService = new UserService(usrRepo);
			return userService;
		}
		public static DestinationService destinationServiceObject()
		{
			DestinationService destinationService = new DestinationService(desRepo);
			return destinationService;
		}
		public static ReviewService reviewServiceObject()
		{
			ReviewService revService = new ReviewService(revRepo);
			return revService;
		}
		public static TravelListService travelListServiceObject()
		{
			TravelListService listService = new TravelListService(travListRepo);
			return listService;
		}
	}
}