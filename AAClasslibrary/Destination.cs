
namespace AdventureAisle.Models
{
    public class Destination
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string BriefDescription { get; set; }

        public List<Review> reviews = new List<Review>();

        List<double> ratingList = new List<double>();

        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get; set; }

        public List<string> monuments = new List<string>();

        public Destination(string name, string country, string brief, string currency, string climate)
        {
            this.Name = name;
            this.Country = country;
            this.BriefDescription = brief;
            this.Currency = currency;
            this.Climate = climate;
        }
        public string GetName { get { return this.Name; } }

        public void AddReview(Review r)
        {
            this.reviews.Add(r);
        }
        public List<Review> GetReviewList { get{ return this.reviews; } }

        public void AddRating(double rating) { this.ratingList.Add(rating); }
        public double CalculateAverage()
        {
            var average = this.ratingList.Average();
            return average;
        } 
    }
}
