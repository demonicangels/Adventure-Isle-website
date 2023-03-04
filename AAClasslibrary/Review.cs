namespace AdventureAisle.Models
{
    public class Review
    {
        User owner;
        string destination;
        double rating;
        string reviewtxt;
       

        public Review(User ow, string des, double rat, string txt) 
        {
            this.owner = ow;
            this.destination = des;
            this.rating = rat;
            this.reviewtxt = txt;
        }
        public string GetReview(double avg)
        {
            return $"{this.owner.GetUserName} rated {this.destination} with avergae rating: {avg} Review: {this.reviewtxt}";
        }


    }
}
