using DAL.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IUserRepository
    {
       
        void InsertUser(UserDTO user);

        void DeleteUser(string userEmail);

        List<UserDTO> GetAllUsers();

        bool Authentication(UserDTO usr);

        UserDTO GetUserByName(string username);

        UserDTO GetUserById(int id);

        void InsertImage(byte[] image, string username);
    }
}
