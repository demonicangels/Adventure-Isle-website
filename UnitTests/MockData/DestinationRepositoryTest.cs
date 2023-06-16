using BusinessLogic;
using System;


namespace UnitTests.MockData
{
    internal class DestinationRepositoryTest : IDestinationRepository
    {
		private List<DestinationDTO> desList = new List<DestinationDTO>()
		{
            new DestinationDTO() { Id = 1, Name = "Brussels", Climate = "Continental", UsrId = 234 },
			new DestinationDTO() { Id = 2, Name = "Eindhoven", Climate = "Continental", UsrId = 234 },
			new DestinationDTO() { Id = 3, Name = "Plovdiv", Climate = "Continental", UsrId = 2 },
            new DestinationDTO() {Id = 4, Name = "Rome", Country = "Italy", Currency = "euro", Climate = "Mostly humid subtropical" , AvgRating = 5 },
            new DestinationDTO() {Id = 6, Name = "Stockholm", Country = "Sweden", Currency = "euro", Climate = "Cold" , AvgRating = 3 },
        };

        public DestinationDTO InsertDestination(DestinationDTO destination)
        {
            desList.Add(destination);
            return destination;
        }
       

        public List<DestinationDTO> GetDestinationByName(string name)
		{
			var destinations = new List<DestinationDTO>();
			foreach (DestinationDTO d in desList)
            {
                if (d.Name.Contains(name))
                {

                    destinations.Add(d);
                }
            }
            return destinations;
        }

		public void DeleteDestination(string selectedDes)
		{
			throw new NotImplementedException();
		}

		public List<DestinationDTO> GetAllDestinationsByCountry(string country)
		{
			throw new NotImplementedException();
		}

		public DestinationDTO UpdateDestination(DestinationDTO des)
		{
			var desi = desList.Where(d => d.Id == des.Id && d.UsrId == des.UsrId).FirstOrDefault();
			desi.AvgRating = des.AvgRating;
			return desi;
		}

		public DestinationDTO SetDestinationStatus(DestinationDTO destination, int usrId)
		{
			throw new NotImplementedException();
		}

		public DestinationDTO GetStatusByUserIdAndDesId(DestinationDTO des, int usrid)
		{
			throw new NotImplementedException();
		}

		public DestinationDTO UpdateStatusByUserIdAndDesId(DestinationDTO des, int usrid)
		{
			var desi = desList.Where(d => d.Id == des.Id && d.UsrId == usrid).FirstOrDefault();
			desi.DesStatus = des.DesStatus;
			return desi;
		}

		public List<DestinationDTO> AllDestinationsofUser(int usrId)
		{
			
			var desUser = desList.Where(u => u.UsrId == usrId).ToList();
			return desUser;
		}

		public List<DestinationDTO> GetAllDestinations()
		{
			return desList;
		}

		public DestinationDTO GetDestinationById(int desId)
		{
			var result = desList.Where(d => d.Id == desId);
			return result.FirstOrDefault();
		}
	}
}
