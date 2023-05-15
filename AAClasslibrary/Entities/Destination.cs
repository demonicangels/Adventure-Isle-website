

using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic
{
    public class Destination
    {
        public int Id { get; set; }
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
		public int? DesStatus { get; set; }



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
            double sum = 0;
            var count = 0;
            foreach(var num in ratingList)
            {
                sum += num;
                count++;

            }
            var average = sum / count;

            var roundedResult = Math.Round(average, 2, MidpointRounding.AwayFromZero);
            AvgRating = roundedResult;
            return AvgRating;
        }
        public string DesInfo()
        {
            return $"{this.Country}: {this.Name}, {this.Currency}, {this.Climate} ";
        }
    }
}
