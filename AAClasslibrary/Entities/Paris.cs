using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Entities
{
    public class Paris : Destination
    {
        public Paris(string name, string country, string brief, string currency, string climate)
        {
            Name = name;
            Country = country;
            BriefDescription = brief;
            Currency = currency;
            Climate = climate;
        }

        public override string GetName { get { return Name; } }
        public override void AddReview(Review r)
        {
            reviews.Add(r);
        }
        public override List<Review> GetReviewList { get { return reviews; } }
        public override void AddRating(double rating) { ratingList.Add(rating); }

        public override double CalculateAverage()
        {
            var average = ratingList.Average();
            return average;
        }
    }
}
