namespace AAClasslibrary.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public User LoggedInAccount { get; set; }

        public User() { }
        public User(string name, string pass, string email)
        {
            username = name;
            password = pass;
            this.email = email;
        }
        public string GetUserName { get { return username; } }
        public string GetPassword { get { return password; } }


    }
}
