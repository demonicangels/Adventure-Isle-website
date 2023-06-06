using BusinessLogic.Entities;
using System.ComponentModel.DataAnnotations;


namespace BusinessLogic
{
    public class UserService
    {
        private IUserRepository _userRepository;
        Security security = new Security();
        int amount;

        public UserService(IUserRepository usr) 
        {
           _userRepository = usr;
        }

        public User FromDTO(UserDTO user)
        {
            User user1 = new User(user.Id, user.Email, user.Password)
            { 
                Username = user.Username,
                UserSince = user.UserSince,
                Birthday = user.Birthday,
                Bio = user.Bio,
                Salt = user.Salt,
                HashedPass = user.HashedPass,
                ProfilePic = user.ProfilePic,
            };
            return user1;
        }
        public UserDTO ToDTO(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
                UserSince = user.UserSince,
                Birthday = user.Birthday,
                Bio = user.Bio,
                Salt = user.Salt,
                HashedPass = user.HashedPass,
                ProfilePic = user.ProfilePic,
            };
            return userDTO;

        }
        public UserDTO InsertUser(UserDTO user, string salt, string hash)
        {
            try
            {
                var userInstance = FromDTO(user);
                
                if (!Validate(userInstance)) { return null; }
                 
                var user2 = _userRepository.InsertUser(user, salt, hash);

                return user2;
            }
            catch(InvalidInformationException i)
            {
                Console.WriteLine(i.Message);
                throw new Exception("Operation failed.Please try again.");
            }
        }
        public void DeleteUser(string email)
        {
            try
            {
                _userRepository.DeleteUser(email);
            }
            catch (CouldntDeleteException c)
            {
                Console.WriteLine(c.Message);
                throw new Exception("Something went wrong. Please try again.");
            }
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(ToDTO(user));
        }
        public User GetUserByName(string name)
        {
            var userDTO = _userRepository.GetUserByName(name);

            var userInstance = FromDTO(userDTO);

            if (!Validate(userInstance)) { return null; }

            return userInstance;
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                var userDTO = _userRepository.GetUserByEmail(email);

                var userInstance = FromDTO(userDTO);

                if (!Validate(userInstance)) { return null; }

                return userInstance;
            }
            catch(FailedToRetrieveInformationException f)
            {
                Console.WriteLine(f.Message);
                throw new Exception("Couldn't find a user with that email.");
            }

        }
        public User GetUserById(int id)
        {
            try
            {
                var userDTO = _userRepository.GetUserById(id);

                var userInstance = FromDTO(userDTO);

                if (!Validate(userInstance)) { return null; }

                return userInstance;
            }
            catch(FailedToRetrieveInformationException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("User not found.");
            }
        }
        public UserDTO[] GetUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return users.ToArray();
            }
            catch(FailedToRetrieveInformationException f)
            {
                Console.WriteLine(f.Message);
                throw new Exception("Something went wrong. Please try again.");
            }
        }

        public User? Authenticate(string email, string pass)
        {
            try
            {
                var loggedInUser = _userRepository.GetUserByEmail(email);

                var expectedHash = security.CreateHash(loggedInUser.Salt, pass);
                var actual = loggedInUser.HashedPass;

                if (expectedHash == actual)
                {
                   return FromDTO(loggedInUser);
                }
                return null; 
            }
            catch(InvalidInformationException i)
            {
                Console.WriteLine(i.Message);
                throw new Exception("Invalid credentials.");
            }
        }

        public void InsertImage(byte[] image, int id)
        {
            try
            {
                _userRepository.InsertImage(image, id);
            }
            catch(InvalidInformationException i)
            {
                Console.WriteLine(i.Message);
                throw new Exception("Something went wrong. Couldn't update profile picture. Please try again.");
            }

        }

        public bool InfoValidation(string name, string email)
        {
            
            var result = int.TryParse(name, out amount);
            var result2 = int.TryParse(email, out amount);

            if (result2 == true)
            {
                result = result2;
            }

            return result;
        }

        public bool SearchValidation(string search) 
        {
            var result = int.TryParse(search, out amount);

            return result;
        }

		public bool Validate(User user)
        {
            var context = new ValidationContext(user);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(user, context, results, true);
        }
    }
} 
