namespace BusinessLogic.Entities
{
    public class Review
    {
        Users owner;
        string destination;
        double rating;
        string reviewtxt;


        public Review(Users ow, string des, double rat, string txt)
        {
            owner = ow;
            destination = des;
            rating = rat;
            reviewtxt = txt;
        }
       // public string GetReview(double avg)
       // {
       //     //return $"{owner.GetUserName} - {destination} avg rating: {avg} Review: {reviewtxt}";
       // }


    }
}
