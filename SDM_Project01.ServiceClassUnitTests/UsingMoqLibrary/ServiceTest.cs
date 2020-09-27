using System;
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
        [TestInitialize]
        public void setup()
        { }


        [TestMethod]
        public void TestGetNumberOfReviewsFromReviewer()//int reviewer)
        {
            Mock<IRepository> mock = new Mock<IRepository>();

            Service service = new Service();

            Review[] returnValue = {new Review  {ReviewId = 1,
                                                   AssociatedMovieId = 1,
                                                   Rating = 4,
                                                   ReviewDate = DateTime.Now.AddDays(-20),
                                                   ReviewerId = 2 },
                                       new Review  {ReviewId = 1,
                                                   AssociatedMovieId = 2,
                                                   Rating = 2,
                                                   ReviewDate = DateTime.Now.AddDays(-30),
                                                   ReviewerId = 2 }
    };
            // Setup up the mock
            mock.Setup(mock => mock.GetAllReviews()).Returns(() => returnValue); 
            //  service.GetNumberOfReviewsFromReviewer(mock.reviewer);
        }
    }
}