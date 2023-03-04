using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary
{
    public class Reviews
    {
        Destination city;
        string review;

        public Reviews(Destination city, string review)
        {
            this.city = city;       
            this.review = review;
        }
    }
}
