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
            var query = $"INSERT INTO Destinations (Name,Country, Currency, History, Climate) VALUES (@Name,@Country, @Currency, @History, @Climate)";
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", des.Name);
            cmd.Parameters.AddWithValue("@Country", des.Country);
            cmd.Parameters.AddWithValue("@Currency", des.Currency);
            cmd.Parameters.AddWithValue("@History", des.BriefDescription);
            cmd.Parameters.AddWithValue("@Climate", des.Climate);
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

        public DestinationDTO GetDestinationByName(string name)
        {
            var query = $"SELECT * FROM Destinations WHERE Name LIKE '{name}%'";
            DestinationDTO d = new DestinationDTO();
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                d.Name = reader["Name"].ToString();
                d.Country = reader["Country"].ToString();
                d.Currency = reader["Currency"].ToString();
                d.BriefDescription = reader["History"].ToString();
                d.Climate = reader["Climate"].ToString();
                d.ImgURL = reader["ImgURL"].ToString();
            }
            con.Close();
            return d;
        }

        public List<DestinationDTO> GetAllDestinations(string country)
        {
            var query = $"SELECT * FROM Destinations where Country = @Country";
            var destinations = new List<DestinationDTO>();
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DestinationDTO des = new DestinationDTO()
                {
                    Name = reader["Name"].ToString(),
                    Currency = reader["Currency"].ToString(),
                    BriefDescription = reader["History"].ToString(),
                    Climate = reader["Climate"].ToString(),
                    ImgURL = reader["ImgURL"].ToString()
                };
                destinations.Add(des);
            }
            con.Close();
            return destinations;

        }

    }
}
