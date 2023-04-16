using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ReviewDTO
    {
        public string UserEmail { get; set; }
        public string DestinationName { get; set; }
        public string ReviewTxt { get; set; }
    }
}
