using BusinessLogic;

namespace BusinessLogic
{
    public interface IDestinationRepository
    {

        void InsertDestination(DestinationDTO destination);

        void DeleteDestination(string selectedDes);

        public DestinationDTO GetDestinationByName(string name);

        List<DestinationDTO> GetAllDestinationsByCountry(string country);

    }
}
