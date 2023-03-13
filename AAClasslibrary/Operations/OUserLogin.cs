using AAClasslibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Operations
{
    public class OUserLogin
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        public void GetData(User usr)
        {
            con.Open();
            cmd = new SqlCommand("SELECT Username, Password FROM LoginData", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usr.username = reader.GetString(2);
                usr.email = reader.GetString(3);
                usr.password = reader.GetString(4);
            }
            reader.Close();
            con.Close();
        }
    }
}
