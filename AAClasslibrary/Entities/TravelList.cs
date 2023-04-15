using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TravelList
    {
        List<string> necessities = new List<string>();
        List<string> custom = new List<string>();
        User owner;

        public void AddToTravelList(string nes)
        {
            necessities.Add(nes);
        }
        public List<string> GetTravelList { get { return necessities; } }
    }
}
