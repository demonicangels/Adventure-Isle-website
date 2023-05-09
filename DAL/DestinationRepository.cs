using Microsoft.Data.SqlClient;
using BusinessLogic;
using System.Collections.Generic;

namespace BusinessLogic 
{
    public class DestinationRepository : IDestinationRepository
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

        public List<DestinationDTO> GetDestinationByName(string name)
        {
            var query = $"SELECT * FROM Destinations WHERE Name LIKE '{name}%'";
            List<DestinationDTO> list = new List<DestinationDTO>();
            con = new SqlConnection(connection);
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DestinationDTO d = new DestinationDTO();
                d.Id = (int)reader["Id"];
                d.Name = reader["Name"].ToString();
                d.Country = reader["Country"].ToString();
                d.Currency = reader["Currency"].ToString();
                d.BriefDescription = reader["History"].ToString();
                d.Climate = reader["Climate"].ToString();
                d.ImgURL = reader["ImgURL"].ToString();
                d.AvgRating = Convert.IsDBNull(reader["AvgRating"]) ? 0 : Convert.ToDouble(reader["AvgRating"]);

                list.Add(d);
            }
            con.Close();
		    return list;
        }

        public List<DestinationDTO> GetAllDestinationsByCountry(string country)
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
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Currency = reader["Currency"].ToString(),
                    BriefDescription = reader["History"].ToString(),
                    Climate = reader["Climate"].ToString(),
                    ImgURL = reader["ImgURL"].ToString(),
                    AvgRating = Convert.IsDBNull(reader["AvgRating"]) ? 0 : Convert.ToDouble(reader["AvgRating"])
            };
                destinations.Add(des);
            }
            con.Close();
            return destinations;

        }

		public DestinationDTO UpdateDestination(DestinationDTO des)
        {
			DestinationDTO des2 = new DestinationDTO();
			var query = "UPDATE [Destinations] SET Name=@NAME, Currency=@cu, AvgRating=@avg, History=@hi, Climate=@cli WHERE Id=@ID";
			SqlConnection con = new SqlConnection(connection);
			con.Open();
			SqlCommand cmd = new SqlCommand(query, con);
			cmd.Parameters.AddWithValue("@ID", des.Id);
			cmd.Parameters.AddWithValue("@NAME", des.Name);
			cmd.Parameters.AddWithValue("@avg", des.AvgRating);
            cmd.Parameters.AddWithValue("@cu", des.Currency);
            cmd.Parameters.AddWithValue("@hi", des.BriefDescription);
			cmd.Parameters.AddWithValue("@cli", des.Climate);
			cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
				des2.Id = (int)reader["Id"];
				des2.Name = reader["Name"].ToString();
				des2.Country = reader["Country"].ToString();
				des2.Currency = reader["Currency"].ToString();
				des2.BriefDescription = reader["History"].ToString();
				des2.Climate = reader["Climate"].ToString();
                des2.AvgRating = (int)reader["AvgRating"];

            }
            return des2;
		}

        public DestinationDTO SetDestinationStatus(DestinationDTO destination, int usrId)
        {
            var query = "INSERT INTO JK_Users_Destinations (UserId, DestinationId, DestinationStatus) VALUES (@id,@iddes,@desStat)";

			using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@id", usrId);
				cmd.Parameters.AddWithValue("@iddes", destination.Id);
				cmd.Parameters.AddWithValue("@desStat", (object)destination.DesStatus ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            return destination;
        }

		public DestinationDTO GetStatusByUserIdAndDesId(DestinationDTO des, int usrid)
		{


			var query = "SELECT * FROM JK_Users_Destinations WHERE UserId = @us AND DestinationId = @dId";
			SqlConnection con = new SqlConnection(connection);
			con.Open();
			SqlCommand cmd2 = new SqlCommand(query, con);
			cmd2.Parameters.AddWithValue("@dId", des.Id);
			cmd2.Parameters.AddWithValue("@us", usrid);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				
		        des.DesStatus = (int)reader["DestinationStatus"];
				

			}
			reader.Close();
			con.Close();
            return des;
		}
	}
}
