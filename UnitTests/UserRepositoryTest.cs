using BusinessLogic;
using System.Security.Cryptography.X509Certificates;

namespace UnitTests
{
    internal class UserRepositoryTest : IUserRepository
    {
       private List<UserDTO> users = new List<UserDTO>();

        public bool Authentication(UserDTO usr)
        {
            var result = false;
            if(usr.Email == "demonic@gmail.com" && usr.Password == "123")
            {
                result = true;
            }
            return result;
        }
		public void InsertUser(UserDTO user, string salt, string hash)
		{
            user.Salt = salt;
			users.Add(user);
		}
		public void DeleteUser(string email)
        {
			var userDto = users.Where(x => x.Email == email).FirstOrDefault();
            users.Remove(userDto);
		}

        public UserDTO[] GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByEmail(string email)
        {
			var userDto = users.Where(x => x.Email == email).FirstOrDefault();
            return userDto;
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public void InsertImage(byte[] image, string username)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}