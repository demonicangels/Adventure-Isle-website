using BusinessLogic;
using DAL.Interfaces;
using DAL;

namespace Factory
{
    public class FactoryService
    {
        private IUserRepository _userRepository;
        private IDestinationRepository _destinationRepository;

        public FactoryService() 
        {
             _userRepository = new UserRepository();
            _destinationRepository = new DestinationRepository();
        }
    }
}
