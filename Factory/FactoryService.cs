using BusinessLogic;
using BusinessLogic.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class FactoryService
    {
        private IUserRepository _userRepository;
        private IDestinationRepository _destinationRepository;

        public FactoryService() 
        {
            UserService userService = new UserService(_userRepository);
            DestinationService desService = new DestinationService("",_destinationRepository);
        }
    }
}
