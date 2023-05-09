using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL;
using Factory;

namespace DesktopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
			IUserRepository _userRepository = new UserRepository();
			IDestinationRepository _destinationRepository = new DestinationRepository();
			IReviewRepository _reviewRepository = new ReviewRepository();
			ITravelListRepository _travelListRepository = new TravelListRepository();
			serviceObjects service = new serviceObjects(_userRepository, _destinationRepository, _reviewRepository, _travelListRepository);

			Application.Run(new CRUDDestinations());
        }
    }
}