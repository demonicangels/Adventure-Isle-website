using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DestinationService
    {
        string dbCountry = "";
        destinationRepo data;
        public DestinationService(string _dbCountry)
        {
            dbCountry = _dbCountry;
            data = new destinationRepo();
        }

        
        public void InsertDestination(DestinationDTO des)
        {
            data.InsertDestination(des);
        }
        public void DeleteDestination(string desName)
        {
            data.DeleteDestination(desName);
        }
        public List<DestinationDTO> GetAllDestinations()
        {
            var destinationList = data.GetAllDestinations(dbCountry);
            return destinationList;
        }
        public DestinationDTO GetDestinationByName(string desName)
        {
            var des = data.GetDestinationByName(desName);
            return des;
        }
    }
}
