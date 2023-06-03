using BusinessLogic;


namespace UnitTests.MockData
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

        public DestinationDTO[] GetAllDestinations(string country)
        {
            throw new NotImplementedException();
        }

        public List<DestinationDTO> GetAllDestinationsByCountry(string country)
        {
            throw new NotImplementedException();
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

        public DestinationDTO UpdateDestination(DestinationDTO des)
        {
            throw new NotImplementedException();
        }

        public DestinationDTO SetDestinationStatus(DestinationDTO destination, int id)
        {
            throw new NotImplementedException();
        }

        public DestinationDTO GetStatusByUserIdAndDesId(DestinationDTO des, int usrid)
        {
            throw new NotImplementedException();
        }

        public DestinationDTO UpdateStatusByUserIdAndDesId(DestinationDTO des, int usrid)
        {
            throw new NotImplementedException();
        }

        public List<DestinationDTO> AllDestinationsofUser(int usrId)
        {
            throw new NotImplementedException();
        }

        public List<DestinationDTO> GetAllDestinations()
        {
            throw new NotImplementedException();
        }

        DestinationDTO IDestinationRepository.InsertDestination(DestinationDTO destination)
        {
            throw new NotImplementedException();
        }
    }
}
