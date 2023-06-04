using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    internal class UsersTest
    {
        public string Username { get; set; }
        public string Password { get; private set; }
        public string? Email { get; private set; }
        public int? Id { get; private set; }
        public DateTime Birthday { get; set; }
        public DateTime UserSince { get; set; }
        public byte[]? ProfilePic { get; set; }
        public string? Bio { get; set; }
        public string? Salt { get; set; }
        public string? HashedPass { get; set; }

        public UsersTest() { }
        public UsersTest(int? id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
