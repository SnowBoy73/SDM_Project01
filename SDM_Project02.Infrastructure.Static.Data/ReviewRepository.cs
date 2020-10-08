using System;
using System.Collections.Generic;
using SDM_Project.Core.Entity;
using SDM_Project.Core.DomainService;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SDM_Project.Infrastructure.Static.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _path = "ratings.json";


        public ReviewRepository()
        {
            GetReviewsFromFile(_path);
            getAllMoviesAvg();
        }

        private IEnumerable<Review> _reviewsCollection;
        private IEnumerable<Movies> _moviesCollection;
        private Dictionary<int, List<int>> movieData;


        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewsCollection;
        }

        public IEnumerable<Movies> getAllMovies()
        {
            return _moviesCollection;
        }

       /* private double getAvg(int id)
        {
            double avg = 0.0;
            var totalMovieRating = 0.0;
            List<Review> result = new List<Review>();
            List<Review> reviews = _reviewsCollection.ToList();
            foreach (Review r in reviews)
            {
                if (r.Movie == id)
                {
                    result.Add(r);
                    totalMovieRating += r.Grade;
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException($"No reviews for reviewer with id {id} were found, so an average is not applicable");
            }
            else
            {
                avg = totalMovieRating / result.Count();
                avg = Math.Round(avg, 2);
            }
            return avg;
        }*/
        public void getAllMoviesAvg()
        {
            
        }

       /* public void getAllMoviesAvg() // 348 hourse est.
        {
            List<Movies> allMovies = new List<Movies>();
            List<int> movieId = new List<int>();

            foreach (var review in _reviewsCollection)
            {
                if (movieId.Contains(review.Movie))
                {

                }
                else
                {

                    movieId.Add(review.Movie);
                    var AvgRating = getAvg(review.Movie);
                    allMovies.Add(new Movies { MovieId = review.Movie, AvgRating = AvgRating });

                }

            }
            _moviesCollection = allMovies;
        }*/


        public void GetReviewsFromFile(string _path)
        {
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var allReviews = new List<Review>();
                Dictionary<int, List<int>> moviedic = new Dictionary<int, List<int>>();
                
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Review review = serializer.Deserialize<Review>(reader);
                        allReviews.Add(review);

                        //
                     
                        {
                            if (moviedic.ContainsKey(review.Movie))
                            {
                                moviedic[review.Movie].Add(review.Grade);
                            
                            }
                            else
                            {
                                List<int> movieGrade = new List<int>();
                                movieGrade.Add(review.Grade);
                                moviedic.Add(review.Movie, movieGrade);
                            }
                        }
                        
                        //
                    }
                    _reviewsCollection = allReviews;
                    
                }
                movieData = moviedic;
                List<Movies> avgList = new List<Movies>();
                foreach (var dicMovie in movieData)
                {
                    int sum = dicMovie.Value.Sum();
                    double Avg = sum / dicMovie.Value.Count;
                    Avg = Math.Round(Avg, 2);
                    avgList.Add(new Movies { MovieId = dicMovie.Key, AvgRating = Avg });
                }
                _moviesCollection = avgList;
            }


        }



    }
}