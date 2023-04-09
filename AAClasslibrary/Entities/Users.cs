using DAL.Interfaces;
using DAL;
using DAL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class Users
    {
        static IUserRepository _userRepository;
        
        public int Id { get; set; }

        public string? Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        public string Password { get; set; }

        public DateTime UserSince { get; set; }

        public Users? LoggedInAccount { get; set; }

        public DateTime Birthday { get; set; }

        public string? Bio { get; set; }

        public Users() { }
        public static IUserRepository GetDAO()
        {
            IUserRepository userRepository = new UserRepository();
            return userRepository;
        }
        public static Users FromDTO(UserDTO user)
        {
            Users user1 = new Users()
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
        private static UserDTO ToDTO(Users user)
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
            _userRepository = GetDAO();
            _userRepository.InsertUser(user);
        }
        public static void DeleteUser(string email)
        {
            _userRepository = GetDAO();
            _userRepository.DeleteUser(email);
        }
        public static Users GetUserByName(string name)
        {
            _userRepository = GetDAO();
            return FromDTO(_userRepository.GetUserByName(name));
        }
        public static Users GetUserByEmail(string email)
        {
            _userRepository = GetDAO();
            return FromDTO(_userRepository.GetUserByEmail(email));
        }
        public static Users GetUserById(int id)
        {
            _userRepository = GetDAO();
            return FromDTO(_userRepository.GetUserById(id));
        }
        public static UserDTO[] GetUsers()
        {
            _userRepository = GetDAO();
            var users = _userRepository.GetAllUsers();
            return users.ToArray();
        }
        public static bool Authenticate(Users user)
        {
            _userRepository = GetDAO();
            var result = _userRepository.Authentication(ToDTO(user));
            return result;
        }
        public string UserInfo()
        {
            return $"{this.Username} :" + " " +
            $"Birthday: {this.Birthday}," +" "+
            $"Email:{this.Email},";
        }
    }
}
