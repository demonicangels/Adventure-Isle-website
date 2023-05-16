using BusinessLogic.Entities;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TravelList
    {
        public int Id { get; internal set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }

        public List<Necessity> Necessities { get; set; } = new List<Necessity>();

    }
}
