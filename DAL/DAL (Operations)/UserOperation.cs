using AAClasslibrary.DAL__Operations_;
using AAClasslibrary.Entities;
using AAClasslibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Operations
{
    public class UserOperation : ICrudUser<UserDTO>
    {
        private string connection = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;

        public void Insert(string sql, UserDTO user)
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue ("@password", user.password);
            cmd.Parameters.AddWithValue ("@email", user.email);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(string sqlCmd, string selectedDes)
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlCmd, con);
            cmd.Parameters.AddWithValue("@username", selectedDes);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<string> GetAll(string sql)
        {
            var names = new List<string>();
            con = new SqlConnection(this.connection);
            con.Open();
            cmd= new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var user = reader["username"].ToString();
                if (user != null)
                {
                    names.Add(user);
                }
            }
            con.Close();
            return names;
        }

        public string Search(string sqlCmd)
        {
            var username = "";
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlCmd, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               username = reader["username"].ToString() +"-"+ reader["email"];
            }
            con.Close();
            return username;
        }



        public string Selected(string sql, string selectedName)
        {
            var info = "";
            con= new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", selectedName);
            cmd.ExecuteNonQuery();
            SqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read()) 
            { 
                info = reader["username"].ToString()+ "-" + reader["email"];
            }
            con.Close();
            return info;
        }

        public bool TryLogin(string sql,string username, string password)
        {
            var boolValue = false;
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (username == reader["username"].ToString() && password == reader["password"].ToString())
                {
                    boolValue = true;
                    return boolValue;
                }
               
            }
            return boolValue;


            
        }


        //public void Insert(string sql, string username, string password, string email)
        //{
        //    con = new SqlConnection(this.connection);
        //    con.Open();
        //    cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@username", username);
        //    cmd.Parameters.AddWithValue ("@password", password);
        //    cmd.Parameters.AddWithValue ("@email", email);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        //
        //public void Delete(string sqlCmd, string selectedDes)
        //{
        //    con= new SqlConnection(this.connection);
        //    con.Open();
        //    cmd = new SqlCommand(sqlCmd, con);
        //    cmd.Parameters.AddWithValue("@username", selectedDes);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        //
        //public List<string> GetAll(string sql)
        //{
        //    var names = new List<string>();
        //    con = new SqlConnection(this.connection);
        //    con.Open();
        //    cmd= new SqlCommand(sql, con);
        //    cmd.ExecuteNonQuery();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var user = reader["username"].ToString();
        //        if (user != null)
        //        {
        //            names.Add(user);
        //        }
        //    }
        //    con.Close();
        //    return names;
        //
        //}
        //
        //public string GetById(string sqlCmd, int id)
        //{
        //    var username = "";
        //   con = new SqlConnection(this.connection);
        //   con.Open();
        //   cmd = new SqlCommand(sqlCmd, con);
        //   cmd.Parameters.AddWithValue("@Id", id);
        //   cmd.ExecuteNonQuery();
        //   SqlDataReader reader = cmd.ExecuteReader();
        //   while (reader.Read())
        //   {
        //      username = reader["username"].ToString() +"-"+ reader["email"];
        //   }
        //   con.Close();
        //   return username;
        //
        //}
        //
        //public string Selected(string sql, string selectedName)
        //{
        //    var info = "";
        //    con= new SqlConnection(this.connection);
        //    con.Open();
        //    cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@username", selectedName);
        //    cmd.ExecuteNonQuery();
        //    SqlDataReader reader= cmd.ExecuteReader();
        //    while (reader.Read()) 
        //    { 
        //        info = reader["username"].ToString()+ "-" + reader["email"];
        //    }
        //    con.Close();
        //    return info;
        //}
    }
}
