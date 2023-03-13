using AAClasslibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace AdventureAisle.Models
{

    public class DbTest
    {
		public List<User> userslist = new List<User>();

		//public void OnGet()
        //{
        //    
        //    
        //    try
        //    {
        //        string connecctionString = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True";
        //        using (SqlConnection con = new SqlConnection(connecctionString))
        //        {
        //            con.Open();
        //            string sql = "SELECT* FROM LoginData";
        //            using(SqlCommand com = new SqlCommand(sql, con)) //allows to execute the command we gave to the database and get all data
        //            {
        //                using (SqlDataReader reader = com.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        User user = new User();
        //                        user.Id = reader.GetInt32(0);
        //                        user.username = reader.GetString(1);
        //                        user.email = reader.GetString(2);
        //                        user.password = reader.GetString(3);
        //
        //                        userslist.Add(user);
        //                        
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception ex) { }
        //}
    }
    

}
