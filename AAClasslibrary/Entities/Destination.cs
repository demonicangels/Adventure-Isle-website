namespace BusinessLogic.Entities
{
    public class Destination
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string BriefDescription { get; set; }

        public List<Review> reviews = new List<Review>();

        public List<double> ratingList = new List<double>();

        public List<string> monuments = new List<string>();
       
        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get; set; }

        public string ImgURL { get; set; }

        public Destination() { }
       public Destination(string name, string country, string briefDescription, string currency, string climate)
       {
           Name = name;
           Country = country;
           BriefDescription = briefDescription;
           Currency = currency;
           Climate = climate;
       }

        public void AddReview(Review r)
        {
            reviews.Add(r);
        }

        public List<Review> GetReviewList { get { return this.reviews; } }

        public void AddRating(double rating)
        {
            ratingList.Add(rating);
        }
        public double CalculateAverage()
        {
            var average = ratingList.Average();
            return average;
        }

    }
}
