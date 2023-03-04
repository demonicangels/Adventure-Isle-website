namespace AdventureAisle.Models
{
    public class Destination
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string BriefDescription { get; set; }

        public List<Review> Reviews = new List<Review>();
        
        public double AvgRating { get; set; }
        public string Currency { get; set; }
        public string Climate { get; set; }
        public List<string> Monuments = new List<string>();

         

    }
}
