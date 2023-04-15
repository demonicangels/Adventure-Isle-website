using Microsoft.Data.SqlClient;
using BusinessLogic;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private string connection = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;

        public void InsertUser(UserDTO user, string salt, string hash)
        {
            var query = "INSERT INTO Users (username, email, birthday, Salt, Hash) VALUES (@username, @email,@birthday, @salt, @hash)";
            using (con = new SqlConnection(connection))
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@birthday", user.Birthday);
				cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@hash", hash);
				cmd.ExecuteNonQuery();
                con.Close();
            }

        }
		public void Update(UserDTO user)
		{
			var query = "UPDATE Users SET username = @us, email = @em, birthday = @birth, bio = @bio WHERE email = @em ";
			using (SqlConnection con = new SqlConnection(connection))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@em", user.Email);
				cmd.Parameters.AddWithValue("@us", user.Username);
				cmd.Parameters.AddWithValue("@birth", user.Birthday);
				cmd.Parameters.AddWithValue("@bio", user.Bio);
				cmd.ExecuteNonQuery();
			}
		}
		public void DeleteUser(string email)
        {
            var query = "DELETE FROM Users WHERE email = @email";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
		public UserDTO[] GetAllUsers()
        {
            var users = new List<UserDTO>();
            var query = "SELECT * FROM Users";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserDTO usr = new UserDTO();
                    usr.Username = reader["username"].ToString();
                    usr.Password = null;
                    usr.Email = reader["email"].ToString();
                    usr.Birthday = (DateTime)reader["birthday"];
                    if (usr != null)
                    {
                        users.Add(usr);
                    }
                }
                con.Close();
                return users.ToArray();
            }
        }
        
        public bool Authentication(UserDTO usr)
        {
            var boolValue = false;
            var query = "SELECT email, password FROM Users";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (usr.Email == reader["email"].ToString() && usr.HashedPass == reader["Hash"].ToString())
                    {
                        boolValue = true;
                        return boolValue;
                    }

                }
                con.Close();
                return boolValue;
            }
        }
        public UserDTO GetUserByName(string name)
        {
            var query = "SELECT * FROM Users WHERE username LIKE @username + '%'";
            UserDTO u = new UserDTO();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", name);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.Id = Convert.ToInt32(reader["Id"]);
                    u.Username = reader["username"].ToString();
					u.Password = null;
					u.Email = reader["email"].ToString();
                    u.Birthday = (DateTime)reader["birthday"];
                    u.Bio = reader["bio"].ToString();
                    u.UserSince = (DateTime)reader["created_at"];
                };
            }
            return u;
        }
        public UserDTO GetUserByEmail(string email)
        {
            var query = "SELECT * FROM Users WHERE email LIKE @email + '%'";
            UserDTO u = new UserDTO();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.Id = Convert.ToInt32(reader["Id"]);
                    u.Username = reader["username"].ToString();
                    u.Password = null;
                    u.Email = reader["email"].ToString();
                    u.Birthday = (DateTime)reader["birthday"];
                    u.Bio = reader["bio"].ToString();
                    u.UserSince = (DateTime)reader["created_at"];
                    u.Salt = reader["Salt"].ToString() ;
                    u.HashedPass = reader["Hash"].ToString();
				};
            }
            return u;
        }
        public UserDTO GetUserById(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @Id";
            UserDTO u = new UserDTO();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.Id = id;
                    u.Username = reader["username"].ToString();
                    u.Password = null;
                    u.Email = reader["email"].ToString();
                    u.UserSince = (DateTime)reader["created_at"];
                    u.Birthday = (DateTime)reader["birthday"];
                    u.Bio = reader["bio"].ToString();
                    //u.profilePic = /*(byte[]?)((byte[])reader["ProfilePicture"] == null ? (object)DBNull.Value :*/ (byte[])reader["ProfilePicture"];
                }

            }
            return u;
        }
        public void InsertImage(byte[] image, string username)
        {
            var query = @"UPDATE Users SET ProfilePicture = @pp WHERE username = @username";
            using (con = new SqlConnection(connection))
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pp", image);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

		
	}
}
