using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AdventureAisle.Models
{
	public class Db
	{
		public List<User> userslist = new List<User>();
		User user = new User();


		public void OnGet()
		{

			try
			{
				string connecctionString = "Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True";
				using (SqlConnection con = new SqlConnection(connecctionString))
				{
					con.Open();
					string sql = "SELECT* FROM LoginData";
					using (SqlCommand com = new SqlCommand(sql, con)) //allows to execute the command we gave to the database and get all data
					{
						using (SqlDataReader reader = com.ExecuteReader())
						{
							while (reader.Read())
							{

								user.Id = reader.GetInt32(0);
								user.username = reader.GetString(1);
								user.email = reader.GetString(2);
								user.password = reader.GetString(3);

								userslist.Add(user);

							}
						}
					}
				}
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}



		//SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True;Trust Server Certificate=true");
		//
		//public int LoginCheck([Bind]User u)
		//{
		//   
		//    SqlCommand com = new SqlCommand("LoginCheck", con);
		//    com.CommandType = CommandType.StoredProcedure;
		//    SqlParameter oblogin = new SqlParameter();
		//    oblogin.ParameterName = "isCorrect";
		//    oblogin.SqlDbType = SqlDbType.Bit;
		//    oblogin.Direction = ParameterDirection.Output;
		//    com.Parameters.Add(oblogin);
		//    con.Open();
		//    com.ExecuteNonQuery();
		//    int res = Convert.ToInt32(oblogin.Value);
		//    con.Close();
		//    return res;
		//
		//
		//}

	}
}
