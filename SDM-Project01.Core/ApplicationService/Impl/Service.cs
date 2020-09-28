using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SDM_Project01.Core.DomianService;
using SDM_Project01.Core.Entity;

namespace SDM_Project01.Core.ApplicationService.Impl
{
    public class Service : IService
    {
        IRepository _repo;
        public Service(IRepository repo)
        {
            _repo = repo;
        }



        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();

            foreach (Review r in reviews)
            {
                if (r.ReviewerId == reviewer)
                {
                    result.Add(r);
                }
                
            }

            if(result.Count == 0) 
            {
                throw new ArgumentException($"no reviews for reviewer with id {reviewer} were found");
                
            }
            return result.Count();
        }


        public double GetAverageRateFromReviewer(int reviewer)
        {
            double avg = 0.0;
            var totalRating = 0.0;

            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            

            foreach (Review r in reviews)
            {
                if (r.ReviewerId == reviewer)
                {
                    result.Add(r);
                    totalRating += r.Rating;
                }

            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"no reviews for reviewer with id {reviewer} were found, Average is not applicable");
            }
            else 
            {
            avg = totalRating / result.Count();
            avg = Math.Round(avg,2);
            }
            return avg;
        }


        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();

            foreach (Review r in reviews)
            {
                if (r.ReviewerId == reviewer && r.Rating == rate)
                {
                    result.Add(r);

                }
            }
                return result.Count;
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
