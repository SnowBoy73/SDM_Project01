using System.Collections.Generic;
using SDM_Project.Core.Entity;

namespace SDM_Project.Core.DomainService
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();

        IEnumerable<Movie> getAllMovies();
    }

}

