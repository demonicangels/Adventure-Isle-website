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

        public ReviewService(IReviewRepository rev)
        {
            _reviewRepository = rev;
		}
        private ReviewDTO ToDTO(Review review)
        {
            var r = new ReviewDTO()
            {
                UserId = review.UserId,
                DestinationId = review.DestinationId,
                ReviewTxt = review.ReviewTxt,
                Rating = review.Rating,
            };
            return r;
        }
        private Review FromDTO(ReviewDTO reviewDTO)
        {
            var r = new Review() 
            {
				UserId = reviewDTO.UserId,
				DestinationId = reviewDTO.DestinationId,
				ReviewTxt = reviewDTO.ReviewTxt,
                Rating = reviewDTO.Rating,
            };
            return r;
        }
        public void Insert(Review review)
        {
            try
            {
                if (!Validate(review))
                {
                    return;
                }
                _reviewRepository.Insert(ToDTO(review));
            }
            catch (InvalidInformationException x)
            {
                Console.WriteLine(x.Message);
                throw new Exception("Invalid information. Insert failed. Please try again.");
            }

        }
        public Review[] GetReviewsByDesId(int id)
        {
            try
            {
                var listDTO = _reviewRepository.GetReviewsByDesId(id);
                List<Review> reviews = new List<Review>();
                foreach (var review in listDTO)
                {
                    reviews.Add(FromDTO(review));
                }
                return reviews.ToArray();
            }
            catch(InvalidInformationException x)
            {
                Console.WriteLine(x.Message);
                throw new Exception("Something went wrong. Couldn't load reviews. Please try again later.");
            }
        }
		public Review[] GetReviews()
        {
            try
            {
			    var listDTO = _reviewRepository.GetReviews();
			    List<Review> reviews = new List<Review>();
			    foreach (var review in listDTO)
			    {
			    	reviews.Add(FromDTO(review));
			    }
			    return reviews.ToArray();
            }
            catch(FailedToRetrieveInformationException x)
            {
                Console.WriteLine(x.Message);
                throw new Exception("Failed to load reviews. Please try again later.");
            }
		}

		public bool Validate(Review re)
        {
            var context = new ValidationContext(re);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(re, context, results, true);
        }
    }
}
