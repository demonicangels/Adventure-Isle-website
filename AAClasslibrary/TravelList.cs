using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary
{
    public class TravelList
    {
        List<string> necessities = new List<string>();
        List<string> custom = new List<string>();

        public void AddToTravelList(string nes)
        {
            necessities.Add(nes);
        }
        public List<string> GetTravelList()
        {
            return this.necessities;
        }
    }
}
