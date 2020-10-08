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
            service.GetAllReviewers();  // list all reviewers
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfReviewsFromReviewer()
        {
            service.GetNumberOfReviewsFromReviewer(1);  // reviewer
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetAverageRateOfMovie()
        {
            service.GetAverageRateOfMovie(30878);  // movie
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfRatesByReviewerr()
        {
            service.GetNumberOfRatesByReviewer(1,5);  // reviewer, rating
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfReviews()
        {
            service.GetNumberOfReviews(1141189);  // movie
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetNumberOfRates()
        {
            service.GetNumberOfRates(493945, 2);  // movie, rating
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetMoviesWithHighestNumberOfTopRates()
        {
            service.GetMoviesWithHighestNumberOfTopRates();  // all movies with a rating of 5
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetMostProductiveReviewers()
        {
            service.GetMostProductiveReviewers();  // list of most prductive reviewerers ids
        }



        [TestMethod]
        [Timeout(180000)]
        public void TestPerformanceGetTopRatedMovies()
        {
            service.GetTopRatedMovies(10);  // returns the given number of top movies
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetTopMoviesByReviewer()
        {
            service.GetTopMoviesByReviewer(1);  // reviewer
        }



        [TestMethod]
        [Timeout(4000)]
        public void TestPerformanceGetReviewersByMovie()
        {
            service.GetReviewersByMovie(30878);  // movie
        }



      
    }
}
