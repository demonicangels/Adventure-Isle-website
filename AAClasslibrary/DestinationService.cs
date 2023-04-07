using BusinessLogic.Interfaces;
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
        IDestinationRepository _destinationRepository;
        public DestinationService(string _dbCountry, IDestinationRepository destinationRepository)
        {
            dbCountry = _dbCountry;
            _destinationRepository = destinationRepository;
        }

        
        public void InsertDestination(DestinationDTO des)
        {
            _destinationRepository.InsertDestination(des);
        }
        public void DeleteDestination(string desName)
        {
            _destinationRepository.DeleteDestination(desName);
        }
        public List<DestinationDTO> GetAllDestinations()
        {
            var destinationList = _destinationRepository.GetAllDestinations(dbCountry);
            return destinationList;
        }
        public DestinationDTO GetDestinationByName(string desName)
        {
            var des = _destinationRepository.GetDestinationByName(desName);
            return des;
        }
    }
}
