﻿using BusinessLogic;


namespace UnitTests
{
    public class DestinationRepositoryTest : IDestinationRepository
    {
        private List<DestinationDTO> desList = new List<DestinationDTO>();

		public void InsertDestination(DestinationDTO destination)
		{
			desList.Add(destination);
		}
		public void DeleteDestination(string selectedDes)
        {
            throw new NotImplementedException();
        }

        public List<DestinationDTO> GetAllDestinations(string country)
        {
            throw new NotImplementedException();
        }

		public List<DestinationDTO> GetAllDestinationsByCountry(string country)
		{
			throw new NotImplementedException();
		}

		public DestinationDTO GetDestinationByName(string name)
        {
            DestinationDTO desi = null;
            foreach(DestinationDTO d in desList)
            {
                if (d.Name.Contains(name))
                {
                    desi = d;
                }
            }
            return desi;
        }

        
    }
}