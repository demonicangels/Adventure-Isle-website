using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class UserDTO
    {


        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        public string username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 20 characters")]
        public string password { get; set; }


        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }

        public int Id { get; set; }
        public DateTime birthday { get; set; }

        public DateTime userSince { get; set; }
    }
}
