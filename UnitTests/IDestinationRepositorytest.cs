using UnitTests.MockData;

namespace UnitTests
{
    internal interface IDestinationRepositorytest
    {
        void InsertDestination(DestinationsTest destination);
        void DeleteDestination(string selectedDes);
        DestinationsTest[] GetAllDestinations(string country);
        List<DestinationsTest> GetAllDestinationsByCountry(string country);
        List<DestinationsTest> GetDestinationByName(string name);
        DestinationsTest UpdateDestination(DestinationsTest des);
        DestinationsTest SetDestinationStatus(DestinationsTest destination, int id);
        DestinationsTest GetStatusByUserIdAndDesId(DestinationsTest des, int usrid);
        DestinationsTest UpdateStatusByUserIdAndDesId(DestinationsTest des, int usrid);
        List<DestinationsTest> AllDestinationsofUser(int usrId);
        List<DestinationsTest> GetAllDestinations();
    }
}