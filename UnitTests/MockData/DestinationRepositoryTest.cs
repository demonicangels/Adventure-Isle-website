using BusinessLogic;


namespace UnitTests.MockData
{
    internal class DestinationRepositoryTest : IDestinationRepository
    {
        private List<DestinationDTO> desList = new List<DestinationDTO>();

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
			var desUser = desList.Where(u => u.UsrId == usrId);
			return desUser.ToList();
		}

		public List<DestinationDTO> GetAllDestinations()
		{
			throw new NotImplementedException();
		}

		public DestinationDTO GetDestinationById(int desId)
		{
			var result = desList.Where(d => d.Id == desId);
			return result.FirstOrDefault();
		}
	}
}
