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
        DestinationDTO SetDestinationStatus(DestinationDTO destination, int usrId);
		DestinationDTO GetStatusByUserIdAndDesId(DestinationDTO des, int usrid);
        DestinationDTO UpdateStatusByUserIdAndDesId(DestinationDTO des, int usrid);
		List<DestinationDTO> AllBeenToDestinationsofUser(int usrId);
        List<DestinationDTO> GetAllDestinations();

	}
}
