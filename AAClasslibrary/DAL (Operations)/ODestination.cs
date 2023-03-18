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
    public class ODestination : ICrudDestination<string>
    {

        //CRUD
        string connection;
        SqlConnection con;
        SqlCommand cmd;

        public ODestination(string _connection)
        {
            this.connection = _connection;
        }
        public void Insert(string sql, string country, string name, string currency, string history)
        {
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Currency", currency);
            cmd.Parameters.AddWithValue("@History", history);
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
        public string GetById(string sqlCmdGetbyId, int chosenId)
        {
            var info = "";
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlCmdGetbyId, con);
            cmd.Parameters.AddWithValue("@ID", chosenId);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                info = reader["Name"] + "-" + reader["Country"] + " " + "Currency: " + reader["Currency"];
            }
            con.Close();
            return info;
        }
        public List<string> GetAll(string sqlCmdGetAll)
        {
            var listNames = new List<string>();
            con= new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlCmdGetAll, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var name = reader["Name"].ToString();
                listNames.Add(name);
            }
            con.Close();
            return listNames;
        }
        public string Selected(string sqlSlected, string selectedName)
        {
            var selectedInfo = "";
            con = new SqlConnection(this.connection);
            con.Open();
            cmd = new SqlCommand(sqlSlected, con);
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
