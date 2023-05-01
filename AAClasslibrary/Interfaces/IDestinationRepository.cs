using BusinessLogic;

namespace BusinessLogic
{
    public interface IDestinationRepository
    {

        void InsertDestination(DestinationDTO destination);

        void DeleteDestination(string selectedDes);

        public List<DestinationDTO> GetDestinationByName(string name);

        List<DestinationDTO> GetAllDestinationsByCountry(string country);
        DestinationDTO UpdateDestination(DestinationDTO des);

	}
}
