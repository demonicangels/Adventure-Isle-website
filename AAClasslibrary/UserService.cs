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
                Username = user.username,
                Password = user.password,
                Email = user.email,
                UserSince = user.userSince,
                Birthday = user.birthday,
                Bio = user.Bio,
            };
            return user1;
        }
        private static UserDTO ToDTO(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                username = user.Username,
                password = user.Password,
                email = user.Email,
                userSince = user.UserSince,
                birthday = user.Birthday,
                Bio = user.Bio,
            };
            return userDTO;

        }
        public static void InsertUser(UserDTO user)
        {
            // userDto copy to user
            var userInstance = FromDTO(user);

            // validate user object and copy user to userdto
            if (!Validate(userInstance))
            {
                return;
            }
            // if all ok? then insert into database with userDto 
            _userRepository.InsertUser(user);

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
            // userDto copy to user
             var userInstance = FromDTO(userDTO);
            // validate user object and copy user to userdto
            if (Validate(userInstance) == true)
            {
                // copy user to userDto
                userDTO = ToDTO(userInstance);
            }
            
            return FromDTO(_userRepository.GetUserByName(name));
        }
        public static User GetUserByEmail(string email)
        {
            var userDTO = _userRepository.GetUserByEmail(email);
            // userDto copy to user
            var userInstance = FromDTO(userDTO);
            // validate user object and copy user to userdto
            if (Validate(userInstance) == true)
            {
                userDTO = ToDTO(userInstance);
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
        public static bool Authenticate(User user)
        {
            var result = _userRepository.Authentication(ToDTO(user));
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
