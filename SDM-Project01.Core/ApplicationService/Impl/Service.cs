using System;
using System.Collections.Generic;

namespace SDM_Project01.Core.ApplicationService.Impl
{
    public class Service: IService
    {
         

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return 0;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            return 0;

        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return 0;

        }

        public int GetNumberOfReviews(int movie)
        {
            return 0;

        }

        public double GetAverageRateOfMovie(int movie)
        {
            return 0;

        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return 0;

        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return null;

        }

        public List<int> GetMostProductiveReviewers()
        {
            return null;

        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return null;
    
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return null;

        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return null;

        }

    }
}
