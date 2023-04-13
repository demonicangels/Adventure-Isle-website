﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class User
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
        public User? LoggedInAccount { get; set; }
        public DateTime Birthday { get; set; }
        public string? Bio { get; set; }
        public string UserInfo()
        {
            return $"{this.Username} :" + " " +
            $"Birthday: {this.Birthday}," + " " +
            $"Email:{this.Email},";
        }
    }
}
