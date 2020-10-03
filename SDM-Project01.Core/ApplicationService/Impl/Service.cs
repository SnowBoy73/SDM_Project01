using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SDM_Project01.Core.DomianService;
using SDM_Project01.Core.Entity;
using System.Collections;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Specialized;

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
                if (r.ReviewerId == reviewer)
                {
                    result.Add(r);
                    totalRating += r.Rating;
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
                if (r.ReviewerId == reviewer && r.Rating == rate)
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
                if (r.AssociatedMovieId == movie)
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
                if (r.AssociatedMovieId == movie)
                {
                    result.Add(r);
                    totalMovieRating += r.Rating;
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
                if (r.AssociatedMovieId == movie && r.Rating == rate)
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
                if (r.Rating == 5)
                {
                    intlist.Add(r.AssociatedMovieId);
                }
            }
            if (intlist.Count == 0)
            {
                throw new ArgumentException("No movie with rate of 5 found");
            }
            return intlist;
        }



        public List<int> GetMostProductiveReviewers()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            var intlist = new List<int>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            foreach (Review r in reviews)
            {
                int rid = r.ReviewerId;
                if (dic.Count == 0)
                {
                    dic.Add(rid, 1);
                }
                else
                {
                    bool isfound = false;
                    for (int index = 0; index < dic.Count; index++)
                    {
                        var item = dic.ElementAt(index);
                        var itemKey = item.Key;
                        var itemValue = item.Value;
                        if (itemKey == rid)
                        {
                            itemValue++;
                            dic[itemKey] = itemValue;
                            isfound = true;
                            break;
                        }
                    }
                    if (isfound == false)
                    {
                        dic.Add(rid, 1);
                    }
                }
            }
            var sortedDict = from entry in dic orderby entry.Value descending select entry;
            var topId = 0;
            var topval = 0;
            foreach (KeyValuePair<int, int> sd in sortedDict)
            {
                if (intlist.Count == 0)
                {
                    topval = (int)sortedDict.First().Value;
                    topId = (int)sortedDict.First().Key;
                    intlist.Add(topId);
                }
                else 
                {
                    if(topval == sd.Value)
                    {
                        intlist.Add(sd.Key);
                    }
                }
            }
            if (intlist.Count == 0)
            {
                throw new ArgumentException("There is no review to be found");
            }
            return intlist;
        }

        

        public List<int> GetTopRatedMovies(int amount)
        {
            Dictionary<int, double> avgDicList = new Dictionary<int, double>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            List<int> movieIdList = new List<int>();
            foreach (Review r in reviews)
            {
                int mid = r.AssociatedMovieId;
                if (movieIdList.Count == 0)
                {
                    movieIdList.Add(mid);
                }
                else
                {
                    bool isfound = false;
                    for (int index = 0; index < movieIdList.Count; index++)
                    {
                        if (movieIdList[index] == mid)
                        {
                            isfound = true;
                            break;
                        }
                    }
                    if (isfound == false)
                    {
                        movieIdList.Add(mid);
                    }
                }
            }
            foreach (var MovieId in movieIdList)
            {
                avgDicList[MovieId] = GetAverageRateOfMovie(MovieId);
            }
            List<int> topMovies = new List<int>();
            var sortedAvgList = from entry in avgDicList orderby entry.Value descending select entry;
            var topId = 0;
            var topval = 0;
            foreach (KeyValuePair<int, double> sal in sortedAvgList)
            {
                if (topMovies.Count == 0)
                {
                    topval = (int)sortedAvgList.First().Value;
                    topId = (int)sortedAvgList.First().Key;
                    topMovies.Add(topId);
                }
                else
                {
                    if (topval == sal.Value)
                    {
                        if (topId != sal.Key)
                        {
                            topMovies.Add(sal.Key);
                        }
                    }
                }
            }
            if (topMovies.Count == 0)
            {
                throw new ArgumentException("there is no review to be found");
            }
            return topMovies;
        }



        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            List<int> returnList = new List<int>();
            List<Review> reviews = _repo.GetAllReviews().ToList();
            List<Review> sortedReviews = reviews
              .Where(rid => rid.ReviewerId == reviewer)
              .OrderByDescending(rating => rating.Rating)
              .ThenByDescending(date => date.ReviewDate)
              .ToList();
          
            foreach (Review r in sortedReviews)
            {
                int id = r.AssociatedMovieId;
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
              .Where(mid => mid.AssociatedMovieId == movie)
              .OrderByDescending(rating => rating.Rating)
              .ThenByDescending(date => date.ReviewDate)
              .ToList();
            foreach (Review r in sortedReviews)
            {
                int id = r.ReviewerId;
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
