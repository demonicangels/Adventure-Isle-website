

using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic
{
    public class Destination
    {

        //make a constructor and make every sensitive info private 
        //create method setId in destination class to be able to change later 

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
        public int? UsrId { get; set; }
		public int TimesVisited { get; set; }

		AlgorithmService algorithm = new AlgorithmService();

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
            var result = algorithm.CalculateAverage(ratingList);
            return result;
		}
        public string DesInfo()
        {
            return $"{this.Country}: {this.Name}, {this.Currency}, {this.Climate} ";
        }
    }
}
