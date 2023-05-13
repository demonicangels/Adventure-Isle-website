using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL;
using Factory;
using FactoryServices;

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

			IRepositoryFactory repositoryFactory = new setRepositories();
			serviceObjects service = new serviceObjects(repositoryFactory);

			Application.Run(new CRUDDestinations());
        }
    }
}