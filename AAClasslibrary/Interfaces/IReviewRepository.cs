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
        void Update();
        void Delete();
        ReviewDTO[] GetReviews();
        ReviewDTO[] GetReviewsByDesId(int id);

	}
}
