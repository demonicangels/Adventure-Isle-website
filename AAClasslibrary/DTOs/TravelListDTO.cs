using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class TravelListDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public List<Necessity> Necessities { get; set; } = new List<Necessity>();
    }
}
