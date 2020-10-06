using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SDM_Project.Core.ApplicationService.Impl;
using SDM_Project.Core.DomainService;
using SDM_Project.Core.Entity;

namespace SDM_Project.UnitTests
{
    [TestClass]
    public class ServiceTest
    {
        Review[] returnValue1 = {new Review   { Movie = 1,
                                                Grade = 4,
                                                Date = DateTime.Now.AddDays(-20),
                                                Reviewer = 1 },

                                new Review  {   Movie = 2,
                                                Grade = 2,
                                                Date = DateTime.Now.AddDays(-30),
                                                Reviewer = 1 },

                                new Review  {   Movie = 3,
                                                Grade = 2,
                                                Date = DateTime.Now.AddDays(-25),
                                                Reviewer = 1 },

                                new Review  {   Movie = 2,
                                                Grade = 2,
                                                Date = DateTime.Now.AddDays(-30),
                                                Reviewer = 2 }, 

                                new Review  {   Movie = 4,
                                                Grade = 5,
                                                Date = DateTime.Now.AddDays(-30),
                                                Reviewer = 2 },

                                new Review  {   Movie = 2,
                                                Grade = 2,
                                                Date = DateTime.Now.AddDays(-3),
                                                Reviewer = 3 },

                                new Review  {   Movie = 3,
                                                Grade = 2,
                                                Date = DateTime.Now.AddDays(-42),
                                                Reviewer = 3 },

                                new Review  {   Movie = 1,
                                                Grade = 4,
                                                Date = DateTime.Now.AddDays(-30),
                                                Reviewer = 4 },

                                new Review  {   Movie = 2,
                                                Grade = 5,
                                                Date = DateTime.Now.AddDays(-30),
                                                Reviewer = 4 },

                                new Review  {   Movie = 4,
                                                Grade = 5,
                                                Date = DateTime.Now.AddDays(-12),
                                                Reviewer = 4 },
        };


        Review[] returnValue2 = { };




        [TestInitialize]
        public void setup()
        {
        }


        [TestMethod]
        public void TestGetNumberOfReviewsFromReviewer()
        {
            //  Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Reviewer 1
            int actualResult = service.GetNumberOfReviewsFromReviewer(2);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2, "IsTrue test failed for reviewer 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for reviewer 1");
            //  Test Reviewer 2
            int actualResult2 = service.GetNumberOfReviewsFromReviewer(1);
            Assert.IsTrue(actualResult2 == 3, "IsTrue test failed for reviewer 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for reviewer 2");
            //  Test Reviewer 3
            int actualResult3 = service.GetNumberOfReviewsFromReviewer(3);
            Assert.IsTrue(actualResult3 == 2, "IsTrue test failed for reviewer 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for reviewer 3");
            //  Test Reviewer 4
            int actualResult4 = service.GetNumberOfReviewsFromReviewer(4);
            Assert.IsTrue(actualResult4 == 3, "IsTrue test failed for reviewer 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for reviewer 4");
            //  Test Exception for most productive reviewers
            Assert.ThrowsException<ArgumentException>(() => service.GetNumberOfReviewsFromReviewer(200));
        }



        [TestMethod]
        public void TestGetAverageRateFromReviewer()
        {
            //  Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Reviewer 1
            double actualResult = service.GetAverageRateFromReviewer(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2.67, "IsTrue test failed for reviewer 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for reviewer 1");
            //  Test Reviewer 2
            double actualResult2 = service.GetAverageRateFromReviewer(2);
            Assert.IsTrue(actualResult2 == 3.5, "IsTrue test failed for reviewer 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for reviewer 2");
            //  Test Reviewer 3
            double actualResult3 = service.GetAverageRateFromReviewer(3);
            Assert.IsTrue(actualResult3 == 2, "IsTrue test failed for reviewer 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for reviewer 3");
            //  Test Reviewer 4
            double actualResult4 = service.GetAverageRateFromReviewer(4);
            Assert.IsTrue(actualResult4 == 4.67, "IsTrue test failed for reviewer 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for reviewer 4");
            //  Test Exception for average from reviewer
            Assert.ThrowsException<ArgumentException>(() => service.GetAverageRateFromReviewer(200));
        }



        [TestMethod]
        public void TestGetNumberOfRatesByReviewer()
        {
            //  Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Reviewer 1
            int actualResult = service.GetNumberOfRatesByReviewer(1, 4);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 1, "IsTrue test failed for reviewer 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for reviewer 1");
            //  Test Reviewer 2
            int actualResult2 = service.GetNumberOfRatesByReviewer(2, 1);
            Assert.IsTrue(actualResult2 == 0, "IsTrue test failed for reviewer 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for reviewer 2");
            //  Test Reviewer 3
            int actualResult3 = service.GetNumberOfRatesByReviewer(3, 2);
            Assert.IsTrue(actualResult3 == 2, "IsTrue test failed for reviewer 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for reviewer 3");
            //  Test Reviewer 4
            int actualResult4 = service.GetNumberOfRatesByReviewer(4, 5);
            Assert.IsTrue(actualResult4 == 2, "IsTrue test failedt for reviewer 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for reviewer 4");
        }



        [TestMethod]
        public void TestGetNumberOfReviews()
        {
            //  Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Movie 1
            int actualResult = service.GetNumberOfReviews(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2, "IsTrue test failed for movie 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for movie 1");
            //  Test Movie 2
            int actualResult2 = service.GetNumberOfReviews(2);
            Assert.IsTrue(actualResult2 == 4, "IsTrue test failed for movie 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for movie 2");
            //  Test Movie 3
            int actualResult3 = service.GetNumberOfReviews(3);
            Assert.IsTrue(actualResult3 == 2, "IsTrue test failed for movie 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for movie 3");
            //  Test Movie 4
            int actualResult4 = service.GetNumberOfReviews(4);
            Assert.IsTrue(actualResult4 == 2, "IsTrue test failed for movie 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for movie 4");
            //  Test Exception for number of reviews
            Assert.ThrowsException<ArgumentException>(() => service.GetAverageRateFromReviewer(200));
        }



        [TestMethod]
        public void TestGetAverageRateOfMovie()
        {
            //  Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Movie 1
            double actualResult = service.GetAverageRateOfMovie(1);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 4, "IsTrue test failed for movie 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for movie 1");
            //  Test Movie 2
            double actualResult2 = service.GetAverageRateOfMovie(2);
            Assert.IsTrue(actualResult2 == 2.75, "IsTrue test failed for movie 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for movie 2");
            //  Test Movie 3
            double actualResult3 = service.GetAverageRateOfMovie(3);
            Assert.IsTrue(actualResult3 == 2, "IsTrue test failed for movie 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for movie 3");
            //  Test Movie 4
            double actualResult4 = service.GetAverageRateOfMovie(4);
            Assert.IsTrue(actualResult4 ==5, "IsTrue test failed for movie 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for movie 4");
            //  Test Exception for average rate for movie
            Assert.ThrowsException<ArgumentException>(() => service.GetAverageRateFromReviewer(200));
        }



        [TestMethod]
        public void TestGetNumberOfRates()
        {
            //  Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Movie 1
            int actualResult = service.GetNumberOfRates(1, 4);
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(actualResult == 2, "IsTrue test failed for movie 1");
            Assert.IsFalse(actualResult == 22, "IsFalse test failed for movie 1");
            //  Test Movie 2
            int actualResult2 = service.GetNumberOfRates(2, 2);
            Assert.IsTrue(actualResult2 == 3, "IsTrue test failed for movie 2");
            Assert.IsFalse(actualResult2 == 22, "IsFalse test failed for movie 2");
            //  Test Movie 3
            int actualResult3 = service.GetNumberOfRates(3, 5);
            Assert.IsTrue(actualResult3 == 0, "IsTrue test failed for movie 3");
            Assert.IsFalse(actualResult3 == 22, "IsFalse test failed for movie 3");
            //  Test Movie 4
            int actualResult4 = service.GetNumberOfRates(4, 5);
            Assert.IsTrue(actualResult4 == 2, "IsTrue test failed for movie 4");
            Assert.IsFalse(actualResult4 == 22, "IsFalse test failed for movie 4");
            //  Test Exception for number of specified rates for movie
            Assert.ThrowsException<ArgumentException>(() => service.GetAverageRateFromReviewer(200));
        }



        [TestMethod]
        public void TestGetMoviesWithHighestNumberOfTopRates()
        {
            // Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Top Rates 1
            List<int> actualResult = service.GetMoviesWithHighestNumberOfTopRates();
            mock.Verify(mock => mock.GetAllReviews());
            List<int> x = new List<int>() { 4, 2 };  // this in not meant to repeat
            Assert.IsTrue(Enumerable.SequenceEqual(x, actualResult), "True test failed for top rates 1");
            Assert.IsFalse(actualResult.Equals(22), "IsFalse test failed for top rates 1");

            // Setup the mock2
            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue2);
            ReviewService service2 = new ReviewService(mock2.Object);
            //  Test Exception for top rates
            Assert.ThrowsException<ArgumentException>(() => service2.GetMoviesWithHighestNumberOfTopRates());
        }



        [TestMethod]
        public void TestGetMostProductiveReviewers()
        {
            // Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Productive Reviewers 1
            List<int> actualResult = service.GetMostProductiveReviewers();
            mock.Verify(mock => mock.GetAllReviews());
            List<int> x = new List<int>() { 1, 4 };
            Assert.IsTrue(Enumerable.SequenceEqual(x, actualResult), "IsTrue test failed for most productive reviewers");
            Assert.IsFalse(actualResult.Equals(22), "IsFalse test failed for most productive reviewers");

            //  Setup up the mock2
            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue2);
            ReviewService service2 = new ReviewService(mock2.Object);
            //  Test Exception for most productive reviewers
            Assert.ThrowsException<ArgumentException>(() => service2.GetMostProductiveReviewers());
        }




        [TestMethod]
        public void GetTopRatedMovies()
        {
            // Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test top movies 1
            List<int> actualResult = service.GetTopRatedMovies(1);
            mock.Verify(mock => mock.GetAllReviews());
            List<int> x1 = new List<int>() { 4 };
            Assert.IsTrue(Enumerable.SequenceEqual(x1, actualResult), "IsTrue test failed for top rated movies");
            Assert.IsFalse(actualResult.Equals(22), "IsFalse test failed for top rated movies");
            //  Test top movies 2
            List<int> actualResult2 = service.GetTopRatedMovies(3);
            List<int> x2 = new List<int>() { 4, 1, 2 };
            Assert.IsTrue(Enumerable.SequenceEqual(x2, actualResult2), "IsTrue test failed for top rated movies");
            Assert.IsFalse(actualResult2.Equals(22), "IsFalse test failed for top rated movies");
            //  Test top movies 3
            List<int> actualResult3 = service.GetTopRatedMovies(4);
            List<int> x3 = new List<int>() { 4, 1, 2, 3 };
            Assert.IsTrue(Enumerable.SequenceEqual(x3, actualResult3), "IsTrue test failed for top rated movies");
            Assert.IsFalse(actualResult3.Equals(22), "IsFalse test failed for top rated movies");
            //  Test top movies 4
            List<int> actualResult4 = service.GetTopRatedMovies(7);
            List<int> x4 = new List<int>() { 4, 1, 2, 3 };
            Assert.IsTrue(Enumerable.SequenceEqual(x4, actualResult4), "IsTrue test failed for top rated movies");
            Assert.IsFalse(actualResult4.Equals(22), "IsFalse test failed for top rated movies");
            //  Test top movies 5
            List<int> actualResult5 = service.GetTopRatedMovies(0);
            List<int> x5 = new List<int>() { };
            Assert.IsTrue(Enumerable.SequenceEqual(x5, actualResult5), "IsTrue test failed for top rated movies");
            Assert.IsFalse(actualResult5.Equals(22), "IsFalse test failed for top rated movies");

            // Setup up the mock2
            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue2);
            ReviewService service2 = new ReviewService(mock2.Object);
            //  Test Exception for Reviewer 1
            Assert.ThrowsException<ArgumentException>(() => service2.GetTopMoviesByReviewer(2));
        }



        [TestMethod]
        public void TestGetTopMoviesByReviewer()
        {
            //  Setup up the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Movies for Reviewer 1
            List<int> actualResult = service.GetTopMoviesByReviewer(1);
            List<int> x1 = new List<int>() { 1, 3, 2 };
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(Enumerable.SequenceEqual(x1, actualResult), "IsTrue test failed for reviewer 1");
            Assert.IsFalse(actualResult.Equals(22), "IsFalse test failed for reviewer 1");
            //  Test Movies for Reviewer 2
            List<int> actualResult2 = service.GetTopMoviesByReviewer(2);
            List<int> x2 = new List<int>() { 4, 2 };
            Assert.IsTrue(Enumerable.SequenceEqual(x2, actualResult2), "IsTrue test failed for reviewer 2");
            Assert.IsFalse(actualResult2.Equals(22), "IsFalse test failed for reviewer 2");
            //  Test Movies for Reviewer 3
            List<int> actualResult3 = service.GetTopMoviesByReviewer(3);
            List<int> x3 = new List<int>() { 2, 3 };
            Assert.IsTrue(Enumerable.SequenceEqual(x3, actualResult3), "IsTrue test failed for reviewer 3");
            Assert.IsFalse(actualResult3.Equals(22), "IsFalse test failed for reviewer 3");
            //  Test Movies for Reviewer 4
            List<int> actualResult4 = service.GetTopMoviesByReviewer(4);
            List<int> x4 = new List<int>() { 4, 2, 1 };
            Assert.IsTrue(Enumerable.SequenceEqual(x4, actualResult4), "IsTrue test failed for reviewer 4");
            Assert.IsFalse(actualResult4.Equals(22), "IsFalse test failed for reviewer 4");

            // Setup up the mock2
            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue2);
            ReviewService service2 = new ReviewService(mock2.Object);
            //  Test Exception for Reviewer 1
            Assert.ThrowsException<ArgumentException>(() => service2.GetTopMoviesByReviewer(1));
        }



        [TestMethod]
        public void TestGetReviewersByMovie()
        {
            // Setup the mock
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue1);
            ReviewService service = new ReviewService(mock.Object);
            //  Test Movie 1
            List<int> actualResult = service.GetReviewersByMovie(1);
            List<int> x1 = new List<int>() { 1, 4 };
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(Enumerable.SequenceEqual(x1, actualResult), "IsTrue test failed for movie 1");
            Assert.IsFalse(actualResult.Equals(22), "IsFalse test failed for movie 1");
            //  Test Movie 2
            List<int> actualResult2 = service.GetReviewersByMovie(2);
            List<int> x2 = new List<int>() { 4, 3, 2, 1 };
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(Enumerable.SequenceEqual(x2, actualResult2), "IsTrue test failed for movie 2");
            Assert.IsFalse(actualResult2.Equals(22), "IsFalse test failed for movie 2");
            //  Test Movie 3
            List<int> actualResult3 = service.GetReviewersByMovie(3);
            List<int> x3 = new List<int>() { 1, 3 };
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(Enumerable.SequenceEqual(x3, actualResult3), "IsTrue test failed for movie 3");
            Assert.IsFalse(actualResult3.Equals(22), "IsFalse test failed for movie 3");
            //  Test Movie 4
            List<int> actualResult4 = service.GetReviewersByMovie(4);
            List<int> x4 = new List<int>() { 4, 2 };
            mock.Verify(mock => mock.GetAllReviews());
            Assert.IsTrue(Enumerable.SequenceEqual(x4, actualResult4), "IsTrue test failed for movie 4");
            Assert.IsFalse(actualResult4.Equals(22), "IsFalse test failed for movie 4");

            // Setup the mock2
            Mock<IReviewRepository> mock2 = new Mock<IReviewRepository>();
            mock2.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue2);
            ReviewService service2 = new ReviewService(mock2.Object);
            //  Test Exception for Reviewer 1
            Assert.ThrowsException<ArgumentException>(() => service2.GetReviewersByMovie(1));
        }
      
    }


}

