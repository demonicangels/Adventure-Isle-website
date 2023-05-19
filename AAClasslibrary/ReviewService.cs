﻿using BusinessLogic.DTOs;
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
            if (!Validate(review))
            {
                return;
            }
            _reviewRepository.Insert(ToDTO(review));

        }
        public Review[] GetReviewsByDesId(int id)
        {
            var listDTO = _reviewRepository.GetReviewsByDesId(id);
            List<Review> reviews = new List<Review>();
            foreach (var review in listDTO)
            {
                reviews.Add(FromDTO(review));
            }
            return reviews.ToArray();
        }
		public Review[] GetReviews()
        {
			var listDTO = _reviewRepository.GetReviews();
			List<Review> reviews = new List<Review>();
			foreach (var review in listDTO)
			{
				reviews.Add(FromDTO(review));
			}
			return reviews.ToArray();
		}

		public bool Validate(Review re)
        {
            var context = new ValidationContext(re);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(re, context, results, true);
        }
    }
}
