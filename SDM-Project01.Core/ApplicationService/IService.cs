using System;
using System.Collections.Generic;
using SDM_Project01.Core.Entity;

namespace SDM_Project01.Core.ApplicationService
{
    public interface IService
    {
        int GetNumberOfReviewsFromReviewer(int reviewer);

        double GetAverageRateFromReviewer(int reviewer);

        int GetNumberOfRatesByReviewer(int reviewer, int rate);

        int GetNumberOfReviews(int movie);

        double GetAverageRateOfMovie(int movie);

        int GetNumberOfRates(int movie, int rate);

        List<int> GetMoviesWithHighestNumberOfTopRates();

        List<int> GetMostProductiveReviewers();

        List<int> GetTopRatedMovies(int amount);

        List<int> GetTopMoviesByReviewer(int reviewer);

        List<int> GetReviewersByMovie(int movie);

    }
}
