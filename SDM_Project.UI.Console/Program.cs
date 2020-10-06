using System;
using System.Collections.Generic;
using SDM_Project.Core.Entity;
using SDM_Project.Core;
using SDM_Project.Core.DomainService;
using SDM_Project.Infrastructure.Static.Data;
using SDM_Project.Core.ApplicationService.Impl;

namespace SDM_Project.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IReviewRepository reviewRepository = new ReviewRepository();
            List<Review> allReviews = (List<Review>)reviewRepository.GetAllReviews();
            ReviewService reviewService = new ReviewService(reviewRepository);
         //   List<Reviewer> allReviewers = reviewService.GetAllReviewers();
         /*   for (int i = 0; i < Math.Min(allReviewers.Count, 100); i++)
            {
                Reviewer r = allReviewers[i];
               // reviewService.WriteListOfReviewers(r.ReviewerId, r.ReviewersReviews.Count);
               // Console.WriteLine("Reviewer = " + r.ReviewerId + " count = " + r.ReviewersReviews.Count);
            }*/
        }

    }
}
