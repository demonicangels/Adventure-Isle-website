using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class TravelListDTO
    {
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public List<string> Necessities { get; set; } = new List<string>();
    }
}
