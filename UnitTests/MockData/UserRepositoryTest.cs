using BusinessLogic;

namespace UnitTests.MockData
{
    internal class UserRepositoryTest : IUserRepository
    {
        private List<UserDTO> users = new List<UserDTO>();

        public bool Authentication(UserDTO usr)
        {
            var result = false;
            if (usr.Email == "demonic@gmail.com" && usr.Password == "123")
            {
                result = true;
            }
            return result;
        }
        public UserDTO InsertUser(UserDTO user, string salt, string hash)
        {
            user.Salt = salt;
            users.Add(user);
            UserDTO u = new UserDTO();
            return u;
        }
        public void DeleteUser(UserDTO u)
        {
            var userDto = users.Where(x => x.Id == u.Id).FirstOrDefault();
            users.Remove(userDto);
        }

        public UserDTO[] GetAllUsers()
        {
            users.Add(new UserDTO() { Email = "pls@gmail.com", Password = "123" });
            users.Add(new UserDTO() { Email = "no@gmail.com", Password = "123" });
            return users.ToArray();
        }

        public UserDTO GetUserByEmail(string email)
        {
            var userDto = users.Where(x => x.Email == email).FirstOrDefault();
            return userDto;
        }

		public void Update(UserDTO user)
		{
			throw new NotImplementedException();
		}

		public UserDTO GetUserById(int id)
		{
			throw new NotImplementedException();
		}

		public UserDTO GetUserByName(string name)
		{
			throw new NotImplementedException();
		}

		public UserDTO InsertImage(byte[] image, int id)
		{
			throw new NotImplementedException();
		}
	}
}