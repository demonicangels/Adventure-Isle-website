using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockData;

namespace UnitTests
{
    internal interface IUserRepositoryTest
    {
        UsersTest InsertUser(UsersTest user, string salt, string hash);
        void Update(UsersTest user);
        void DeleteUser(string email);
        UsersTest[] GetAllUsers();

        bool Authentication(UsersTest usr);

        UsersTest GetUserByEmail(string email);

        UsersTest GetUserById(int id);

        UsersTest GetUserByName(string name);

        void InsertImage(byte[] image, int id);
    }
}
