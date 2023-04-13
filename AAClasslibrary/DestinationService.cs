using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DestinationService
    {
        private static IDestinationRepository _destinationRepository;
        public static void Initialize(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }
        public static void InsertDestination(DestinationDTO destination)
        {


        }

        //void DeleteDestination(string selectedDes);
        //
        //public DestinationDTO GetDestinationByName(string name);
        //
        //List<DestinationDTO> GetAllDestinations(string country);
    }
}
