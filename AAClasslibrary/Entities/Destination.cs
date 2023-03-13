namespace AAClasslibrary.Entities
{
    public abstract class Destination
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string BriefDescription { get; set; }

        protected List<Review> reviews = new List<Review>();

        protected List<double> ratingList = new List<double>();

        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get; set; }

        protected List<string> monuments = new List<string>();

        public abstract string GetName { get; }

        public abstract void AddReview(Review r);

        public abstract List<Review> GetReviewList { get; }

        public abstract void AddRating(double rating);
        public abstract double CalculateAverage();

    }
}
