using BusinessLogic;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReviewRepository : IReviewRepository
    {
        private string connection = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Insert(ReviewDTO review)
        {
            string query = "INSERT INTO Reviews (UserEmail, DestinationName, ReviewTxt, Rating) VALUES (@user, @des, @review, @rate)";
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", review.UserEmail);
                cmd.Parameters.AddWithValue("@des", review.DestinationName);
                cmd.Parameters.AddWithValue("@review", review.ReviewTxt);
				cmd.Parameters.AddWithValue("@rate", review.Rating);
				cmd.ExecuteNonQuery();
            }
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ReviewDTO[] GetReviews(string des)
        {
            var query = "SELECT * FROM Reviews WHERE DestinationName = @des ";
            List<ReviewDTO> reviewList = new List<ReviewDTO>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@des", des);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReviewDTO r = new ReviewDTO();
                    r.UserEmail = reader["UserEmail"].ToString();
                    r.DestinationName = reader["DestinationName"].ToString();
                    r.ReviewTxt = reader["ReviewTxt"].ToString();
                    r.Rating = Convert.ToDouble(reader["Rating"].ToString());
                    reviewList.Add(r);
                }
            }
            return reviewList.ToArray();
        }

        
    }
}
