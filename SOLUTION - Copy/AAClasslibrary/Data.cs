using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;


namespace AAClasslibrary
{
    public class Data
    {
        List<Destination> destinations = new List<Destination>();
        public List<Destination> GetData()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1KFDAJ8C\\SQLEXPRESS;Initial Catalog=AdventureAisle;Integrated Security=True"))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand("AdventureAisle", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Paris paris = new Paris();
                            paris.country = reader.GetString(0);
                            paris.name = reader.GetString(1);
                            paris.currency = reader.GetString(2);
                            paris.history = reader.GetString(3);
                            destinations.Add(paris);

                            Rome rome = new Rome();
                            paris.country = reader.GetString(4);
                            paris.name = reader.GetString(5);
                            paris.currency = reader.GetString(6);
                            paris.history = reader.GetString(7);
                            destinations.Add(paris);
                        }
                    }
                }
            }
            return this.destinations;
        }
    }
}

