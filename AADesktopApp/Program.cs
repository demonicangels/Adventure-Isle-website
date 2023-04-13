using BusinessLogic;
using DAL;

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
            IUserRepository userRepository = new UserRepository();
            UserService.Initialize(userRepository);
            Application.Run(new CRUDDestinations());
        }
    }
}