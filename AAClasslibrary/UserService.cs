using BusinessLogic.Interfaces;
using DAL;
using DAL.DTOs;

namespace BusinessLogic
{
    public class UserService 
    {
        private IUserRepository _userRepository;
        

        public UserService(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public void InsertUser(UserDTO user)
        {
            _userRepository.InsertUser(user);
        }
        public void DeleteUser(string userEmail)
        {
            _userRepository.DeleteUser(userEmail);
        }
        public List<UserDTO> GetAllUsers()
        {
            var userList = _userRepository.GetAllUsers();
            return userList;
        }

        public bool TryLogin(UserDTO userCredentials)
        {
            var result = _userRepository.Authentication(userCredentials);
            return result;
        }

        public UserDTO GetUserByName(string username)
        {
            var user = _userRepository.GetUserByName(username);
            return user;
        }
        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return user;
        }
        public void InsertImage(byte[] image, string username)
        {
            _userRepository.InsertImage(image, username);
        }
    }
}
