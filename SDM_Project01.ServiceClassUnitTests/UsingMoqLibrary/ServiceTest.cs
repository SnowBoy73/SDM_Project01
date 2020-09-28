using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SDM_Project01.Core.ApplicationService;
using SDM_Project01.Core.ApplicationService.Impl;
using SDM_Project01.Core.DomianService;
using SDM_Project01.Core.Entity;

namespace SDM_Project01.ServiceClassMockUnitTests
{
    [TestClass]
    public class ServiceTest
    {
        Review[] returnValue = {new Review  {ReviewId = 1,
                                                 AssociatedMovieId = 1,
                                                 Rating = 4,
                                                 ReviewDate = DateTime.Now.AddDays(-20),
                                                 ReviewerId = 1 },

                                    new Review  {ReviewId = 2,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 1 },

                                    new Review  {ReviewId = 3,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 1 },

                                    new Review  {ReviewId = 4,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 2 },

                                    new Review  {ReviewId = 5,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 2 },

                                    new Review  {ReviewId = 6,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 3 },

                                    new Review  {ReviewId = 7,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 3 },

                                    new Review  {ReviewId = 8,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 4 },

                                    new Review  {ReviewId = 9,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 4 },

                                    new Review  {ReviewId = 10,
                                                 AssociatedMovieId = 2,
                                                 Rating = 2,
                                                 ReviewDate = DateTime.Now.AddDays(-30),
                                                 ReviewerId = 4 },

             };
        [TestInitialize]
        public void setup()
        {
           
    }
        [TestMethod]
        public void TestGetNumberOfReviewsFromReviewer()//int reviewer)
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            //
          
   
            // Setup up the mock
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue);

            Service service = new Service(mock.Object);
            int actualResult = service.GetNumberOfReviewsFromReviewer(2);

            mock.Verify(mock => mock.GetAllReviews());//, Times.Once); 
            
            Assert.IsTrue(actualResult == 2,"1");
            Assert.IsFalse(actualResult == 22, "false");
            Assert.ThrowsException<ArgumentException>(() => service.GetNumberOfReviewsFromReviewer(200));

            int actualResult2 = service.GetNumberOfReviewsFromReviewer(1);
            Assert.IsTrue(actualResult2 == 3,"2");
            Assert.IsFalse(actualResult2 == 22, "false2");
            int actualResult3 = service.GetNumberOfReviewsFromReviewer(3);
            Assert.IsTrue(actualResult3 == 2,"3");
            Assert.IsFalse(actualResult3 == 22, "false3");
            int actualResult4 = service.GetNumberOfReviewsFromReviewer(4);
            Assert.IsTrue(actualResult4 == 3,"4");
            Assert.IsFalse(actualResult4 == 22, "false4");
        }

        [TestMethod]
        public void TestGetAverageRateFromReviewer()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            //


            // Setup up the mock
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue);

            Service service = new Service(mock.Object);
            double actualResult = service.GetAverageRateFromReviewer(1);
             
            mock.Verify(mock => mock.GetAllReviews());//, Times.Once); 

            Assert.IsTrue(actualResult == 2.67, "1");
            Assert.IsFalse(actualResult == 22, "false");
            Assert.ThrowsException<ArgumentException>(() => service.GetNumberOfReviewsFromReviewer(200));

        }

    }
}
