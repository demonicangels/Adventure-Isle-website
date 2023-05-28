using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    public class Destinations
    {
        public string Name { get; set; }
        public string Climate { get; set; }
        public Destinations(string n, string c)
        {
            Name = n;
            Climate = c;
        }
    }
}
