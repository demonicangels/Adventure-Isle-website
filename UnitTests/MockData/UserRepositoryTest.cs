using BusinessLogic;

namespace UnitTests.MockData
{
    internal class UserRepositoryTest : IUserRepositoryTest
    {
        private List<UsersTest> users = new List<UsersTest>();

        public bool Authentication(UsersTest usr)
        {
            var result = false;
            if (usr.Email == "demonic@gmail.com" && usr.Password == "123")
            {
                result = true;
            }
            return result;
        }
        public UsersTest InsertUser(UsersTest user, string salt, string hash)
        {
            user.Salt = salt;
            users.Add(user);
            UsersTest u = new UsersTest();
            return u;
        }
        public void DeleteUser(string email)
        {
            var userDto = users.Where(x => x.Email == email).FirstOrDefault();
            users.Remove(userDto);
        }

        public UsersTest[] GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UsersTest GetUserByEmail(string email)
        {
            var userDto = users.Where(x => x.Email == email).FirstOrDefault();
            return userDto;
        }

        public UsersTest GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UsersTest GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public void InsertImage(byte[] image, string username)
        {
            throw new NotImplementedException();
        }

        public void Update(UsersTest user)
        {
            throw new NotImplementedException();
        }

        public void InsertImage(byte[] image, int id)
        {
            throw new NotImplementedException();
        }
    }
}