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
            User user1 = new User()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
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
                Username = user.Username,
                Email = user.Email,
                UserSince = user.UserSince,
                Birthday = user.Birthday,
                Bio = user.Bio,
                Salt = user.Salt,
                HashedPass = user.HashedPass,
                ProfilePic = user.ProfilePic,
            };
            return userDTO;

        }
        public void InsertUser(UserDTO user, string salt, string hash)
        {
            // userDto copy to user
            var userInstance = FromDTO(user);

            // validate user object and copy user to userdto
            if (!Validate(userInstance)) { return; }
            // if all ok? then insert into database with userDto 
            _userRepository.InsertUser(user, salt, hash);

        }
        public void DeleteUser(string email)
        {
            //var dto = _userRepository.GetUserByEmail(email);
            //
            //var userInstance = FromDTO(dto);
            //
            //if (!Validate(userInstance)) {return;}

            _userRepository.DeleteUser(email);
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
            var userDTO = _userRepository.GetUserByEmail(email);

            var userInstance = FromDTO(userDTO);

            if (!Validate(userInstance)) { return null; }

            return userInstance;

        }
        public User GetUserById(int id)
        {
            var userDTO = _userRepository.GetUserById(id);

            var userInstance = FromDTO(userDTO);

            if (!Validate(userInstance)) { return null; }

            return userInstance;
        }
        public UserDTO[] GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.ToArray();
        }

        public User? Authenticate(string email, string pass)
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

        public void InsertImage(byte[] image, string username)
        {
            _userRepository.InsertImage(image, username);
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
