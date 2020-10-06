using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SDM_Project.Core.DomainService;
using SDM_Project.Core.Entity;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SDM_Project.Core.ApplicationService.Impl
{
    public class ReviewService : IReviewService
    {
        static List<Movies> allMovies = new List<Movies>();
        IReviewRepository _repo;
        public ReviewService(IReviewRepository repo)
        {
            //Console.Clear();
            _repo = repo;

            //allMovies = new List<Movies>();

        }


        
        public List<Movies> getAllMovies()
        {
            List<Review> allReviews = _repo.GetAllReviews().ToList();

            
            foreach (var rev in allReviews)
            {
                var AvgRating = GetAverageRateOfMovie(rev.Movie);
                allMovies.Add(new Movies { MovieId = rev.Movie, AvgRating = AvgRating });

            }
            Console.WriteLine(allMovies.Count);
            return allMovies;
        }

        public List<Reviewer> GetAllReviewers()
        {
            Dictionary<int, Reviewer> allReviewers = new Dictionary<int, Reviewer>();
            foreach (Review r in _repo.GetAllReviews())
            {
                int id = r.Reviewer;
                if (allReviewers.ContainsKey(id) == false)
                {
                    Reviewer reviewer = new Reviewer();
                    reviewer.ReviewerId = id;
                    reviewer.ReviewersReviews = new List<Review>();
                    reviewer.ReviewersReviews.Add(r);
                    allReviewers.Add(id, reviewer);
                }
                else
                {
                    allReviewers[id].ReviewersReviews.Add(r);
                }
            }

            return allReviewers.Values.ToList();
        }

        




        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            foreach (Review r in reviews)
            {
                if (r.Reviewer == reviewer)
                {
                    result.Add(r);
                }
            }
            if(result.Count == 0) 
            {
                throw new ArgumentException($"No reviews for reviewer with id {reviewer} were found");
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
                if (r.Reviewer == reviewer)
                {
                    result.Add(r);
                    totalRating += r.Grade;
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"No reviews for reviewer with id {reviewer} were found, so an average is not applicable");
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
                if (r.Reviewer == reviewer && r.Grade == rate)
                {
                    result.Add(r);
                }
            }
            return result.Count;
        }



        public int GetNumberOfReviews(int movie)
        {
            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            foreach (Review r in reviews)
            {
                if (r.Movie == movie)
                {
                    result.Add(r);
                }
            }
            return result.Count;
        }



        public double GetAverageRateOfMovie(int movie)
        {
            double avg = 0.0;
            var totalMovieRating = 0.0;
            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            foreach (Review r in reviews)
            {
                if (r.Movie == movie)
                {
                    result.Add(r);
                    totalMovieRating += r.Grade;
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"No reviews for reviewer with id {movie} were found, so an average is not applicable");
            }
            else
            {
                avg = totalMovieRating / result.Count();
                avg = Math.Round(avg, 2);
            }
            return avg;
        }



        public int GetNumberOfRates(int movie, int rate)
        {
            List<Review> result = new List<Review>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            if(rate < 1 || rate > 5)
            {
                throw new ArgumentException("Rating needs to be a numbur between 1-5");
            }
            foreach (Review r in reviews)
            {
                if (r.Movie == movie && r.Grade == rate)
                {
                    result.Add(r);
                }
            }
            return result.Count;
        }



        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var intlist = new List<int>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            foreach (Review r in reviews)
            {
                if (r.Grade == 5)
                {
                    intlist.Add(r.Movie);
                }
            }
            if (intlist.Count == 0)
            {
                throw new ArgumentException("No movie with rate of 5 found");
            }
            var topMovies = intlist.Distinct().ToList(); //Removes duplicates
            return topMovies;
        }




        public List<int> GetMostProductiveReviewers()
        {          
            List<Review> allReviews = _repo.GetAllReviews().ToList();
            var allReviewers = GetAllReviewers().ToList();

            int topCount = 0;
            var topList = new List<int>();
            foreach (var Rev in allReviewers)
            {
               var revCount = Rev.ReviewersReviews.Count();

                if (revCount > topCount)
                {
                    topList.Clear();
                    topList.Add(Rev.ReviewerId);
                    topCount = revCount;

                }
                if (revCount == topCount)
                {
                    topList.Add(Rev.ReviewerId);
                    topCount = revCount;
                }

            }
            var returnList = topList.Distinct().ToList();
            if (returnList.Count == 0)
            {
                throw new ArgumentException("There is no review to be found");
            }
            return returnList; 
        }



        public List<int> GetTopRatedMovies(int amount)
        {
            if(allMovies.Count == 0)
            {
                getAllMovies();
            }
            var dAllMovies = allMovies.Distinct().ToList();
            List<Movies> sortedMovies = dAllMovies
              .OrderByDescending(AvgRating => AvgRating.AvgRating)
              .ToList();
            
             

            if (sortedMovies.Count == 0)
            {
                throw new ArgumentException("there is no reviews to be found");
            }
            if (amount > sortedMovies.Count)
            {
                amount = sortedMovies.Count();
            }
            List<int> limitedTopMovies = new List<int>();
            List<int> dlimitedTopMovies = limitedTopMovies.Distinct().ToList();
            for (int i = 0; i < amount; i++)
            {
                int mid = sortedMovies[i].MovieId;
                limitedTopMovies.Add(mid);
            }
            

            return dlimitedTopMovies;
        }



        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            List<int> returnList = new List<int>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            List<Review> sortedReviews = reviews
              .Where(rid => rid.Reviewer == reviewer)
              .OrderByDescending(rating => rating.Grade)
              .ThenByDescending(date => date.Date)
              .ToList();
            foreach (Review r in sortedReviews)
            {
                int id = r.Movie;
                returnList.Add(id);
            }
            if (returnList.Count == 0)
            {
                throw new ArgumentException("there are no movies to be found");
            }
            return returnList;
        }




        public List<int> GetReviewersByMovie(int movie)
        {
            List<int> returnList = new List<int>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            List<Review> sortedReviews = reviews
              .Where(mid => mid.Movie == movie)
              .OrderByDescending(rating => rating.Grade)
              .ThenByDescending(date => date.Date)
              .ToList();
            foreach (Review r in sortedReviews)
            {
                int id = r.Reviewer;
                returnList.Add(id);
            }
            if (returnList.Count == 0)
            {
                throw new ArgumentException("there are no reviewers to be found");
            }
            return returnList;
        }
    }


}
