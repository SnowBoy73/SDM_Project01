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
            ReviewService reviewService = new ReviewService(reviewRepository);
         }

    }
}
