using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class User
    {

        public int Id { get; private set; }
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime UserSince { get; set; }
        public User? LoggedInAccount { get; set; }
        public DateTime Birthday { get; set; }
        public string? Bio { get; set; }
        public string? Salt { get; set; }
        public string? HashedPass { get; set; }
		public byte[]? ProfilePic { get; set; }

        public User() { }
        public User(int? id, string email, string password)
        {
            Id =  (int?)id == null ? 0 : (int)id;
            Email = email;
            Password = password;
        }
		public string UserInfo()
        {
            return $"{this.Username} :" + " " +
            $"Birthday: {this.Birthday}," + " " +
            $"Email:{this.Email},";
        }
    }
}
