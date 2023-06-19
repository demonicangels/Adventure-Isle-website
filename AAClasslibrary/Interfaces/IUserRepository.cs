using BusinessLogic;

namespace BusinessLogic
{
    public interface IUserRepository
    {

        UserDTO InsertUser(UserDTO user, string salt, string hash);
		void Update(UserDTO user);
		void DeleteUser(UserDTO u);
        UserDTO[] GetAllUsers();

        bool Authentication(UserDTO usr);

        UserDTO GetUserByEmail(string email);

        UserDTO GetUserById(int id);

        UserDTO GetUserByName(string name);

        UserDTO InsertImage(byte[] image, int id);
    }
}
