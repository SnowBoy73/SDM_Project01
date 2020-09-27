using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SDM_Project01.Core.ApplicationService;
using SDM_Project01.Core.ApplicationService.Impl;

namespace SDM_Project01.ServiceClassMockUnitTests
{
    [TestClass]
    public class ServiceTest
    {

        [TestMethod]
        public void TestGetNumberOfReviewsFromReviewer()//int reviewer)
        {
            var mock = new Mock<IService>();  // not sure about IService...
                                              // mock.Setup(reviewer => reviewer.GetNumberOfReviewsFromReviewer).Returns(true);
            var service = new Service();
        }
    }
}
