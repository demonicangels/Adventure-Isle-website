using AAClasslibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAClasslibrary.Interfaces;

namespace AAClasslibrary.Operations
{
    public class ODestination : ICrudDestination<DestinationDTO>
    {

        //CRUD
        private string connection = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;

        public void Insert(string sql, DestinationDTO destination)
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Country", destination.Country);
            cmd.Parameters.AddWithValue("@Name", destination.Name);
            cmd.Parameters.AddWithValue("@Currency", destination.Currency);
            cmd.Parameters.AddWithValue("@History", destination.BriefDescription);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(string sqlCmd, string selectedDes)
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlCmd, con);
            cmd.Parameters.AddWithValue("@Name", selectedDes);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string Search(string sqlCmd)
        {
            var info = "";
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlCmd, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                info = reader["Name"] + "-" + reader["Country"] + " " + "Currency: " + reader["Currency"];
            }
            con.Close();
            return info;
        }

        public List<string> GetAll(string sql)
        {
            var listNames = new List<string>();
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                if (name != null)
                {
                    listNames.Add(name);
                }
            }
            con.Close();
            return listNames;
        }

        public string Selected(string sql, string selectedName)
        {
            var selectedInfo = "";
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", selectedName);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                selectedInfo = reader["Country"] + ":" + " " + reader["Name"] + ", " + "Curency: " + reader["Currency"].ToString() + " - " + reader["History"].ToString();
            
            }
            con.Close();
            return selectedInfo;
        }

        

        



    }
}
