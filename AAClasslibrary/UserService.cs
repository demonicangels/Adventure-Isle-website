using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic
{
    public class UserService
    {
        private static IUserRepository _userRepository;

        public static void Initialize(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public static User FromDTO(UserDTO user)
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
				HashedPass = user.HashedPass
			};
            return user1;
        }
        private static UserDTO ToDTO(User user)
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
                HashedPass = user.HashedPass
            };
            return userDTO;

        }
        public static void InsertUser(UserDTO user, string salt, string hash)
        {
            // userDto copy to user
            var userInstance = FromDTO(user);

            // validate user object and copy user to userdto
            if (!Validate(userInstance))
            {
                return;
            }
            // if all ok? then insert into database with userDto 
            _userRepository.InsertUser(user,salt,hash);

        }
        public static void DeleteUser(string email)
        {
            var dto = _userRepository.GetUserByEmail(email);

            var userInstance = FromDTO(dto);

            if (!Validate(userInstance))
            {
                return;
            }

            _userRepository.DeleteUser(email);
        }
        public static User GetUserByName(string name)
        {
            var userDTO = _userRepository.GetUserByName(name);
            
             var userInstance = FromDTO(userDTO);
            
            if (Validate(userInstance) == true)
            {
                userDTO = ToDTO(userInstance);
            }
            
            return FromDTO(_userRepository.GetUserByName(name));
        }
        public static User GetUserByEmail(string email)
        {
            var userDTO = _userRepository.GetUserByEmail(email);
            
            var userInstance = FromDTO(userDTO);
            
            if (Validate(userInstance) == true)
            {
                return FromDTO(_userRepository.GetUserByEmail(email));
            }
            return null;
            
        }
        public static User GetUserById(int id)
        {
            return FromDTO(_userRepository.GetUserById(id));
        }
        public static UserDTO[] GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.ToArray();
        }
        public static bool Authenticate(string email,string pass,string salt, string hashedPassword )
        {
            var result = false;
			var expectedHash = Security.CreateHash(salt, pass);
            var actualHash = UserService.GetUserByEmail(email).HashedPass;

            if(expectedHash == actualHash)
            {
                result = true;
            }
            return result;
        }

        public static bool Validate(User user)
        {
            var context = new ValidationContext(user);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(user, context, results, true);
        }
    }
}
