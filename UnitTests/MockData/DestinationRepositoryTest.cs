using BusinessLogic;


namespace UnitTests.MockData
{
    public class DestinationRepositoryTest : IDestinationRepositorytest
    {
        private List<DestinationsTest> desList = new List<DestinationsTest>();

        public void InsertDestination(DestinationsTest destination)
        {
            desList.Add(destination);
        }
        public void DeleteDestination(string selectedDes)
        {
            throw new NotImplementedException();
        }

        public DestinationsTest[] GetAllDestinations(string country)
        {
            throw new NotImplementedException();
        }

        public List<DestinationsTest> GetAllDestinationsByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public List<DestinationsTest> GetDestinationByName(string name)
        {
            var destinations = new List<DestinationsTest>();
            foreach (DestinationsTest d in desList)
            {
                if (d.Name.Contains(name))
                {

                    destinations.Add(d);
                }
            }
            return destinations;
        }

        public DestinationsTest UpdateDestination(DestinationsTest des)
        {
            throw new NotImplementedException();
        }

        public DestinationsTest SetDestinationStatus(DestinationsTest destination, int id)
        {
            throw new NotImplementedException();
        }

        public DestinationsTest GetStatusByUserIdAndDesId(DestinationsTest des, int usrid)
        {
            throw new NotImplementedException();
        }

        public DestinationsTest UpdateStatusByUserIdAndDesId(DestinationsTest des, int usrid)
        {
            throw new NotImplementedException();
        }

        public List<DestinationsTest> AllDestinationsofUser(int usrId)
        {
            throw new NotImplementedException();
        }

        public List<DestinationsTest> GetAllDestinations()
        {
            throw new NotImplementedException();
        }

        
    }
}
