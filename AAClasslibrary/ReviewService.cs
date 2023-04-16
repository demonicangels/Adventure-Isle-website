using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ReviewService
    {
        private static IReviewRepository _reviewRepository;

        public static void Initialize(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        private static ReviewDTO ToDTO(Review review)
        {
            var r = new ReviewDTO()
            {
                UserEmail = review.UserEmail,
                DestinationName = review.DestinationName,
                ReviewTxt = review.ReviewTxt
            };
            return r;
        }
        private static Review FromDTO(ReviewDTO reviewDTO)
        {
            var r = new Review() 
            {
                UserEmail = reviewDTO.UserEmail,
                DestinationName = reviewDTO.DestinationName,
                ReviewTxt = reviewDTO.ReviewTxt
            };
            return r;
        }
        public static void Insert(Review review)
        {
            if (!Validate(review))
            {
                return;
            }
            _reviewRepository.Insert(ToDTO(review));

        }

        public static Review[] GetReviews(string des)
        {
            var listDTO = _reviewRepository.GetReviews(des);
            List<Review> reviews = new List<Review>();
            foreach (var review in listDTO)
            {
                reviews.Add(FromDTO(review));
            }
            return reviews.ToArray();
        }

        public static bool Validate(Review re)
        {
            var context = new ValidationContext(re);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(re, context, results, true);
        }
    }
}
