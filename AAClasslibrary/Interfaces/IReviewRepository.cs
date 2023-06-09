using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IReviewRepository
    {
        void Insert(ReviewDTO review);
        ReviewDTO UpdateReview(ReviewDTO r);
        void Delete();
        ReviewDTO[] GetReviews();
        ReviewDTO[] GetReviewsByDesId(int id);

	}
}
