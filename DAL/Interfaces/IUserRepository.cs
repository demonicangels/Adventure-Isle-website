using DAL.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IUserRepository<T>
    {
       
        void InsertUser(T user);

        void DeleteUser(string userEmail);

        List<T> GetAllUsers();

        bool TryLogin(string username, string password);

        UserDTO GetUserByName(string username);

        T GetUserById(int id);
    }
}
