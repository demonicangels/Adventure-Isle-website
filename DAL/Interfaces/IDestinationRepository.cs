using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDestinationRepository
    {

        void InsertDestination(DestinationDTO destination);

        void DeleteDestination(string selectedDes);

        public DestinationDTO GetDestinationByName(string name);

        List<DestinationDTO> GetAllDestinations(string country);

    }
}
