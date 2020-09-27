using System;
using System.Collections.Generic;
using SDM_Project01.Core.DomianService;
using SDM_Project01.Core.Entity;

namespace SDM_Project01.Core.ApplicationService.Impl
{
    public class Service: IService
    {
        IRepository _repo;
        public Service(IRepository repo)
        {
            _repo = repo;
        }



        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<Review> result = new List<Review>();
            foreach (Review r in _repo.GetAllReviews())
                if (r.ReviewerId == reviewer)
                    result.Add(r);
            return result.Count();
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


        public void GetNumberOfReviewsFromReviewer(object reviewer)
        {
            throw new NotImplementedException();
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
