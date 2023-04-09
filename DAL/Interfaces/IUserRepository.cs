using DAL.DTOs;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
       
        void InsertUser(UserDTO user);

        void DeleteUser(string email);

        UserDTO[] GetAllUsers();

        bool Authentication(UserDTO usr);

        UserDTO GetUserByEmail(string email);

        UserDTO GetUserById(int id);

        UserDTO GetUserByName(string name);

        void InsertImage(byte[] image, string username);
    }
}
