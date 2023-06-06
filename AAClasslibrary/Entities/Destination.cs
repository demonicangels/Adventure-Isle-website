

using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic
{
    public class Destination
    {

        //make a constructor and make every sensitive info private 
        //create method setId in destination class to be able to change later 

        public int Id { get; private set; } 
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string BriefDescription { get; set; }

        public List<Review> reviews = new List<Review>();

        public List<double> ratingList = new List<double>();
       
        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get; private set; }
        public string ImgURL { get; private set; }
		public int? DesStatus { get; set; }
        public int? UsrId { get; private set; }

		RecommendationsRepo algorithm = new RecommendationsRepo();

        public Destination() { }
        public Destination(int id, string name, string country,string? cur, string? brief, string climate, double? avg, string? img, int? usrId, int? desStatus)
        {
            Id = id;
            Name = name;
            Country = country;
            Climate = climate;
            Currency = cur;
            BriefDescription = brief;
            AvgRating = (double)avg;
            ImgURL = img;
            UsrId = usrId;
            DesStatus = desStatus;
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
            var result = algorithm.CalculateAverage(ratingList);
            return result;
		}
        public string DesInfo()
        {
            return $"{this.Country}: {this.Name}, {this.Currency}, {this.Climate} ";
        }
    }
}
