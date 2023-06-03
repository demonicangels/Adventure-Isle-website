using BusinessLogic.Exceptions;
using Microsoft.Data.SqlClient;

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
            try
            {
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
            catch (Exception ex)
            {
                throw new InvalidInformationException();
            }
        }
        public void DeleteDestination(string selectedDes)
        {
            var query = "DELETE FROM Destinations WHERE NAME = @NAME";

            try
            {
                con = new SqlConnection(connection);
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", selectedDes);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new CouldntDeleteException("Destination couldn't be deleted");
            }
        }

        public List<DestinationDTO> GetDestinationByName(string name)
        { 
            try
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
            catch (Exception ex)
            {
                throw new DestinationNotFoundException("Destination not found");
            }
          
        }

        public List<DestinationDTO> GetAllDestinationsByCountry(string country)
        {
            var query = $"SELECT * FROM Destinations where Country = @Country";
            var destinations = new List<DestinationDTO>();
            try
            {
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
            catch (Exception ex)
            {
                throw new NoDestinationsFoundForCountryException("No destinations for this country are found");
            }

        }

		public DestinationDTO UpdateDestination(DestinationDTO des)
        {
			DestinationDTO des2 = new DestinationDTO();
			var query = "UPDATE [Destinations] SET Name=@NAME, Currency=@cu, AvgRating=@avg, History=@hi, Climate=@cli WHERE Id=@ID";
            try 
            { 
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
            catch (Exception ex)
            {
                throw new FailedToUpdateDestination("Failed to update destination");
            }
            
		}

        public DestinationDTO SetDestinationStatus(DestinationDTO destination, int usrId)
        {
			var query = "INSERT INTO JK_Users_Destinations (UserId, DestinationId, DestinationStatus) VALUES (@id,@iddes,@desStat)";
            try
            {
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
            catch(Exception ex)
            {
                throw new CouldntSetDestinationStatusException("Failed to set destination status.");
            }
        }

		public DestinationDTO GetStatusByUserIdAndDesId(DestinationDTO des, int usrid)
		{
            var query = $"SELECT * FROM Destinations WHERE Name LIKE '{des.Name}%'";
            var query2 = "SELECT * FROM JK_Users_Destinations WHERE UserId = @us AND DestinationId = @dId";

            try
            {
                DestinationDTO dto = new DestinationDTO();
			    con = new SqlConnection(connection);
			    con.Open();
			    cmd = new SqlCommand(query, con);
			    SqlDataReader reader = cmd.ExecuteReader();
			    while (reader.Read())
			    {

			    	dto.Id = (int)reader["Id"];
			    	dto.Name = reader["Name"].ToString();
			    	dto.Country = reader["Country"].ToString();
			    	dto.Currency = reader["Currency"].ToString();
			    	dto.BriefDescription = reader["History"].ToString();
			    	dto.Climate = reader["Climate"].ToString();
			    	dto.ImgURL = reader["ImgURL"].ToString();
			    	dto.AvgRating = Convert.IsDBNull(reader["AvgRating"]) ? 0 : Convert.ToDouble(reader["AvgRating"]);

			    }
                con.Close();
			   
			    SqlConnection con2 = new SqlConnection(connection);
			    con2.Open();
			    SqlCommand cmd2 = new SqlCommand(query2, con2);
			    cmd2.Parameters.AddWithValue("@dId", des.Id);
			    cmd2.Parameters.AddWithValue("@us", usrid);
			    SqlDataReader reader2 = cmd2.ExecuteReader();
			    while (reader2.Read())
			    {
		            des.DesStatus = reader2["DestinationStatus"] == DBNull.Value ? null : (int)reader2["DestinationStatus"];
			    }
			    reader2.Close();
			    con2.Close();

                return des;
            }
            catch(Exception ex)
            {
                throw new InvalidInformationException("Invalid ids");
            }
		}

		public DestinationDTO UpdateStatusByUserIdAndDesId(DestinationDTO des, int usrid)
		{
            var query = "UPDATE JK_Users_Destinations SET DestinationStatus = @stat WHERE UserId = @us AND DestinationId = @dId ";
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@us", usrid);
                cmd.Parameters.AddWithValue("@dId", des.Id);
                cmd.Parameters.AddWithValue("@stat", des.DesStatus);
                cmd.ExecuteNonQuery();
                con.Close();
                return des;
            }
            catch(Exception ex)
            {
                throw new InvalidInformationException("Couldn't update status. Invalid ids.");
            }
		}
        public List<DestinationDTO> GetAllDestinations()
        {
			var query = "SELECT * FROM Destinations";
			var destinations = new List<DestinationDTO>();

            try
            {
			    con = new SqlConnection(connection);
			    con.Open();
			    cmd = new SqlCommand(query, con);
			    cmd.ExecuteNonQuery();
			    SqlDataReader reader = cmd.ExecuteReader();
			    while (reader.Read())
			    {
                    DestinationDTO des = new DestinationDTO()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Country = reader["Country"].ToString(),
			    		Currency = reader["Currency"].ToString(),
			    		BriefDescription = reader["History"].ToString(),
			    		Climate = reader["Climate"].ToString(),
			    		ImgURL = reader["ImgURL"].ToString(),
			    		AvgRating = Convert.IsDBNull(reader["AvgRating"]) ? 0 : Convert.ToDouble(reader["AvgRating"]),
			    	};
			    	destinations.Add(des);
			    }
			    con.Close();
			    return destinations;
            }
            catch(Exception ex)
            {
                throw new FailedToRetrieveInformationException("Failed to retrieve information");
            }
		}
        public DestinationDTO GetDestinationById(int desId)
        {
            var query = "SELECT * FROM Destinations WHERE Id = @id ";
            using (con = new SqlConnection(connection))
            {
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", desId);
                cmd.ExecuteNonQuery();
                DestinationDTO dto = new DestinationDTO();
				SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        dto.Id = (int)reader["Id"];
                        dto.Name = reader["Name"].ToString();
                        dto.Country = reader["Country"].ToString();
                        dto.Currency = reader["Currency"].ToString();
                        dto.BriefDescription = reader["History"].ToString();
                        dto.Climate = reader["Climate"].ToString();
                        dto.ImgURL = reader["ImgURL"].ToString();
                        dto.AvgRating = Convert.IsDBNull(reader["AvgRating"]) ? 0 : Convert.ToDouble(reader["AvgRating"]);	
                }
				return dto;
			}
            
        }
        public List<DestinationDTO> AllDestinationsofUser(int usrId)
        {
            try
            {
                List<DestinationDTO> userDestinations = new List<DestinationDTO>();
                var query = "SELECT * FROM JK_Users_Destinations AS jk " + "INNER JOIN dbo.Destinations AS d ON jk.DestinationId = d.Id " + "INNER JOIN dbo.Users AS u ON jk.UserId = u.Id " + " WHERE UserId = @us";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@us", usrId);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DestinationDTO des = new DestinationDTO()
                        {
                            UsrId = (int)reader["UserId"],
                            Id = (int)reader["DestinationId"],
                            Name = reader["Name"].ToString(),
                            Country = reader["Country"].ToString(),
                            Currency = reader["Currency"].ToString(),
                            BriefDescription = reader["History"].ToString(),
                            Climate = reader["Climate"].ToString(),
                            ImgURL = reader["ImgURL"].ToString(),
                            AvgRating = Convert.IsDBNull(reader["AvgRating"]) ? 0 : Convert.ToDouble(reader["AvgRating"]),
                            DesStatus = (int?)reader["DestinationStatus"]
                        };
                        userDestinations.Add(des);
                    }
                }
                return userDestinations;

            }
            catch(Exception ex)
            {
                throw new CouldntFindUserException("Couldn't find user. Invalid user credentials.");
            }

		}
	}
}
