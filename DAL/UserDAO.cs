using AAClasslibrary.Entities;
using AAClasslibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO : IDatabaseServiceUsers<User>
    {
        private string connection = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;

        public void InsertUser(UserDTO user)
        {
            var query = "INSERT INTO Users (username, password, email) VALUES (@username, @password, @email)";
            using (con = new SqlConnection(connection))
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }
        public void DeleteUser(string selectedDes)
        {
            var query = "DELETE FROM Users WHERE username = @username";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", selectedDes);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            var query = "SELECT * FROM Users";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User usr = new User();
                    usr.username = reader["username"].ToString();
                    usr.password = reader["password"].ToString();
                    usr.email = reader["email"].ToString();
                    if (usr != null)
                    {
                        users.Add(usr);
                    }
                }
                con.Close();
                return users;
            }
        }
        public string SearchUserName(string name)
        {
            var username = "";
            var query = $"SELECT * FROM Users WHERE username LIKE '{name}%'";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    username = reader["username"].ToString();
                }
                con.Close();
                return username;
            }
        }
        public string SelectedUser(string selectedName)
        {
            var info = "";
            var query = "SELECT * FROM Users WHERE username = @username";
            using (con = new SqlConnection(connection))
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", selectedName);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    info = reader["username"].ToString() + "-" + reader["email"];
                }
                con.Close();
                return info;
            }

        }
        public bool TryLogin(string username, string password)
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
                    if (username == reader["username"].ToString() && password == reader["password"].ToString())
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
            using (con = new SqlConnection(this.connection))
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
                }
                
            }
            return u;
        }
        public User GetUserById(int id)
        {   
            var query = "SELECT * FROM Users WHERE Id = @Id";
            User u = new User();
            using (con = new SqlConnection(this.connection))
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
                }

            }
            return u;
        }
    }
}
