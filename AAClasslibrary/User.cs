namespace AdventureAisle.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public User LoggedInAccount { get; set; }

        public User(string usern, string pass, string email) 
        { 
            this.username = usern;
            this.password = pass;
            this.email = email;
        }
        public string GetUserName { get { return this.username; } }
        public string GetPassword { get { return this.password; } }

        
    }
}
