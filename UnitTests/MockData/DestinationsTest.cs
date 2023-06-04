using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    public class DestinationsTest
    {
        public string Name { get; set; }
        public string Climate { get; set; }
        public double? AvgRating { get; set; }
        public string Country { get; set; }

        public List<double> ratingList = new List<double>();

        public DestinationsTest() { }
        public DestinationsTest(string n, string country, string c, double? avgRating)
        {
            Name = n;
            Climate = c;
            AvgRating = avgRating;
            Country = country;
        }
    }
}
