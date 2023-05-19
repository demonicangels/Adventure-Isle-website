namespace BusinessLogic
{
    public class Review
    {
		public int UserId { get; set; }
		public int DestinationId { get; set; }
		public string ReviewTxt { get; set; }
        public double Rating { get; set; }

    }
}
