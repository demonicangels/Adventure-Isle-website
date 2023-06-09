using BusinessLogic;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MockData
{
    internal class ReviewRepositoryTest : IReviewRepository
    {
        List<ReviewDTO> reviews = new List<ReviewDTO>()
        {
            new ReviewDTO(){ UserId = 1, DestinationId = 1, Rating = 5},
            new ReviewDTO(){ UserId = 1,DestinationId = 2, Rating = 4},
            new ReviewDTO(){ UserId = 1, DestinationId = 3, Rating = 3},
            new ReviewDTO(){ UserId = 2, DestinationId = 3, Rating = 3},
            new ReviewDTO(){ UserId = 2, DestinationId = 5, Rating = 1}

        };

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ReviewDTO[] GetReviews()
        {
            return reviews.ToArray();
        }

        public ReviewDTO[] GetReviewsByDesId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ReviewDTO review)
        {
            throw new NotImplementedException();
        }

        public ReviewDTO UpdateReview(ReviewDTO r)
        {
            throw new NotImplementedException();
        }
    }
}
