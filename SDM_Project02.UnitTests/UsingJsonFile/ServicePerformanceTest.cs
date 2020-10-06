using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM_Project.Core.DomainService;
using SDM_Project.Core.ApplicationService.Impl;
using SDM_Project.Infrastructure.Static.Data;
namespace SDM_Project.UnitTests.UsingJsonFile
{

    [TestClass]
    public class ServicePerformanceTest
    {
        private static IReviewRepository reviewRepository;
        

        [ClassInitialize]
        public static void InitialiseRepo(TestContext testContext)
        {
            reviewRepository = new ReviewRepository();
        }

        ReviewService service = new ReviewService(reviewRepository);


        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetAllReviewers()
        {
          //  ReviewService service = new ReviewService(reviewRepository);
            service.GetAllReviewers();  // list all reviewers
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfReviewsFromReviewer()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetNumberOfReviewsFromReviewer(1);  // reviewer
        }



        [TestMethod]
        [Timeout(32000)]
        public void TestPerformanceGetAverageRateOfMovie()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetAverageRateOfMovie(1);  // movie
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfRatesByReviewerr()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetNumberOfRatesByReviewer(1,5);  // reviewer, rating
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfReviews()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetNumberOfReviews(1141189);  // movie
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfRates()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetNumberOfRates(493945, 2);  // movie, rating
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetMoviesWithHighestNumberOfTopRates()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetMoviesWithHighestNumberOfTopRates();  // all movies with a rating of 5
        }



        [TestMethod]
        [Timeout(32000)]
        public void TestPerformanceGetMostProductiveReviewers()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetMostProductiveReviewers();  // list of most prductive reviewerers ids
        }



        [TestMethod]
        [Timeout(32000)]
        public void TestPerformanceGetTopRatedMovies()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetTopRatedMovies(100);  // returns the given number of top movies
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetTopMoviesByReviewer()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetTopMoviesByReviewer(1);  // reviewer
        }



        [TestMethod]
        [Timeout(32000)]
        public void TestPerformanceGetReviewersByMovie()
        {
         //   ReviewService service = new ReviewService(reviewRepository);
            service.GetReviewersByMovie(1);  // movie
        }



      
    }
}
