using Microsoft.Data.SqlClient;
using BusinessLogic.Interfaces;
using DAL.DTOs;

namespace DAL
{
    public class destinationRepo : IDestinationRepository<DestinationDTO>
    {

        //CRUD
        private string connection = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        SqlCommand cmd;

        public void InsertDestination(DestinationDTO des)
        {
            var query = "INSERT INTO Destinations (Country, Name, Currency, History) VALUES (@Country, @Name, @Currency, @History)";
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Country", des.Country);
            cmd.Parameters.AddWithValue("@Name", des.Name);
            cmd.Parameters.AddWithValue("@Currency", des.Currency);
            cmd.Parameters.AddWithValue("@History", des.BriefDescription);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteDestination(string selectedDes)
        {
            var query = "DELETE FROM Destinations WHERE NAME = @NAME";
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", selectedDes);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string GetDestinationByName(string name)
        {
            var query = $"SELECT * FROM Destinations WHERE Name LIKE '{name}%'";
            var info = "";
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                info = reader["Name"] + "-" + reader["Country"] + " " + "Currency: " + reader["Currency"];
            }
            con.Close();
            return info;
        }

        public List<DestinationDTO> GetAllDestinations()
        {
            var query = "SELECT * FROM Destinations WHERE Country = 'France' ";
            var destinations = new List<DestinationDTO>();
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DestinationDTO des = new DestinationDTO()
                {
                    Name = reader["Name"].ToString(),
                    Country = reader["Country"].ToString(),
                    Currency = reader["Currency"].ToString(),
                    BriefDescription = reader["History"].ToString(),
                    ImgURL = reader["ImgURL"].ToString()
                };
                destinations.Add(des);
            }
            con.Close();
            return destinations;

        }

    }
}
