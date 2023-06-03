﻿using BusinessLogic;

namespace BusinessLogic
{
    public interface IUserRepository
    {
       
        void InsertUser(UserDTO user, string salt, string hash);
		void Update(UserDTO user);
		void DeleteUser(string email);
        UserDTO[] GetAllUsers();

        bool Authentication(UserDTO usr);

        UserDTO GetUserByEmail(string email);

        UserDTO GetUserById(int id);

        UserDTO GetUserByName(string name);

        void InsertImage(byte[] image, int id);
    }
}
