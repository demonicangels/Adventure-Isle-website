using BusinessLogic;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TravelListRepository : ITravelListRepository
    {
        private string connection = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public TravelListDTO CreateTravelList(TravelListDTO travelList)
        {
            try
            {
                var query = "INSERT INTO TravelList (UserId) OUTPUT INSERTED.Id VALUES (@usr)";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@usr", travelList.UserId);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                        throw new Exception("Couldn't create list");
                    int id = (int)reader["Id"];
                    travelList.Id = id;
                }

                var query2 = "INSERT INTO Necessities (TravelListId, NAME) VALUES (@id, @n)";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    foreach (var n in travelList.Necessities)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", travelList.Id);
                        cmd.Parameters.AddWithValue("@n", n.Name);
                        cmd.ExecuteNonQuery();
                    }
                }
                return travelList;
            }
            catch (Exception e)
            {
                throw new BusinessLogic.InvalidInformationException("Something went wrong while attempting to insert a TravelList in the database");
            }
        }
        public TravelListDTO GetListByUserId(int id)
        {
            try
            {
                TravelListDTO tr = new TravelListDTO();
                var query = "SELECT * FROM TravelList WHERE UserId = @us";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@us", id);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tr.UserId = id;
                        tr.Id = (int)reader["Id"];
                    }
                }
                var query2 = "SELECT * FROM Necessities WHERE TravelListId = @id ";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@id", tr.Id);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        var nes = new Necessity
                        {
                            Name = (string)reader["Name"],
                        };
                        tr.Necessities.Add( nes );
                    }  
                    return tr;
                }
            }
            catch(Exception x)
            {
                throw new BusinessLogic.InvalidInformationException("Invalid userId. Couldn't load travelList");
            }
        }
        public TravelListDTO UpdateTravelList(TravelListDTO travelList)
        {
            var query2 = "INSERT INTO Necessities (TravelListId, NAME) VALUES (@id, @n)";
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query2, con);
                foreach (var n in travelList.Necessities)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", travelList.Id);
                    cmd.Parameters.AddWithValue("@n", n.Name);
                    cmd.ExecuteNonQuery();
                }
                return travelList;
            }
        }
    }
}
