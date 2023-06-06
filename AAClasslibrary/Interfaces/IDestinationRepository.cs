using BusinessLogic;

namespace BusinessLogic
{
    public interface IDestinationRepository
    {

        DestinationDTO InsertDestination(DestinationDTO destination);
        void DeleteDestination(string selectedDes);
        List<DestinationDTO> GetDestinationByName(string name);
        List<DestinationDTO> GetAllDestinationsByCountry(string country);
        DestinationDTO UpdateDestination(DestinationDTO des);
        DestinationDTO SetDestinationStatus(DestinationDTO destination, int usrId);
		DestinationDTO GetStatusByUserIdAndDesId(DestinationDTO des, int usrid);
        DestinationDTO UpdateStatusByUserIdAndDesId(DestinationDTO des, int usrid);
		List<DestinationDTO> AllDestinationsofUser(int usrId);
        List<DestinationDTO> GetAllDestinations();
        DestinationDTO GetDestinationById(int desId);

	}
}
