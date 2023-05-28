using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    public class ReviewsTest
    {
        public int UserId { get; set; }
        public string Reviewtext { get; set; }
        
        public ReviewsTest(int i, string s)
        {
            UserId = i;
            Reviewtext = s;
        }
    }
}
