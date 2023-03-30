using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DTOs;

namespace BusinessLogic
{
    public class UserService 
    {
        userRepo data = new userRepo();

        public void InsertUser(UserDTO user)
        {
            data.InsertUser(user);
        }
        public void DeleteUser(string userEmail)
        {
            data.DeleteUser(userEmail);
        }
        public List<UserDTO> GetAllUsers()
        {
            var userList = data.GetAllUsers();
            return userList;
        }

        public bool TryLogin(UserDTO userCredentials)
        {
            var result = data.TryLogin(userCredentials.username, userCredentials.password);
            return result;
        }

        public UserDTO GetUserByName(string username)
        {
            var user = data.GetUserByName(username);
            return user;
        }
        public UserDTO GetUserById(int id)
        {
            var user = data.GetUserById(id);
            return user;
        }
    }
}
