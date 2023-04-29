using BusinessLogic;
using BusinessLogic.Interfaces;

namespace Factory
{
	public class serviceObjects
	{
		static IUserRepository usrRepo;
		static IDestinationRepository desRepo;
		static IReviewRepository revRepo;

		public serviceObjects(IUserRepository usr, IDestinationRepository des, IReviewRepository rev) 
		{
			usrRepo = usr;
			desRepo = des;
			revRepo = rev;
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
	}
}