using Microsoft.Data.SqlClient;
using BusinessLogic.Interfaces;
using DAL.DTOs;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private string connection = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;

        public void InsertUser(UserDTO user)
        {
            var query = "INSERT INTO Users (username, password, email, birthday) VALUES (@username, @password, @email,@birthday)";
            using (con = new SqlConnection(connection))
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@birthday", user.birthday);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void DeleteUser(string username)
        {
            var query = "DELETE FROM Users WHERE username = @username";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<UserDTO> GetAllUsers()
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
                    usr.username = reader["username"].ToString();
                    usr.password = reader["password"].ToString();
                    usr.email = reader["email"].ToString();
                    usr.birthday = (DateTime)reader["birthday"];
                    if (usr != null)
                    {
                        users.Add(usr);
                    }
                }
                con.Close();
                return users;
            }
        }
        
        public bool Authentication(UserDTO usr)
        {
            var boolValue = false;
            var query = "SELECT username, password FROM Users";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (usr.username == reader["username"].ToString() && usr.password == reader["password"].ToString())
                    {
                        boolValue = true;
                        return boolValue;
                    }

                }
                con.Close();
                return boolValue;
            }
        }
        public UserDTO GetUserByName(string username)
        {

            var query = "SELECT * FROM Users WHERE username = @username";
            UserDTO u = new UserDTO();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u.Id = Convert.ToInt32(reader["Id"]);
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.email = reader["email"].ToString();
                    u.birthday = (DateTime)reader["birthday"];
                    u.Bio = reader["bio"].ToString();
                    u.userSince = (DateTime)reader["created_at"];
                }

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
                    u.username = reader["username"].ToString();
                    u.password = reader["password"].ToString();
                    u.email = reader["email"].ToString();
                    u.userSince = (DateTime)reader["created_at"];
                    u.birthday = (DateTime)reader["birthday"];
                    u.Bio = reader["bio"].ToString();
                    u.profilePic = /*(byte[]?)((byte[])reader["ProfilePicture"] == null ? (object)DBNull.Value :*/ (byte[])reader["ProfilePicture"];
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
