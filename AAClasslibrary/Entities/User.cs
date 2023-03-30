using System.ComponentModel.DataAnnotations;

namespace AAClasslibrary.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        public string username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public DateTime userSince { get; set; }

        public User LoggedInAccount { get; set; }

        public DateTime birthday { get; set; }

        public User() { }
        public User(string name, string pass, string email)
        {
            username = name;
            password = pass;
            this.email = email;
        }
        public string GetUserName { get { return username; } }
        public string GetPassword { get { return password; } }


    }
}
