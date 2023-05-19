using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ReviewDTO
    {
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public string ReviewTxt { get; set; }

		public double Rating { get; set; }
	}
}
