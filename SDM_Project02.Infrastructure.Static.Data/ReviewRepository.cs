using System;
using System.Collections.Generic;
using SDM_Project.Core.Entity;
using SDM_Project.Core.DomainService;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace SDM_Project.Infrastructure.Static.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _path = "ratings.json";


        public ReviewRepository()
        {
            GetReviewsFromFile(_path);
        }

        private IEnumerable<Review> _reviewsCollection;
        private IEnumerable<Movie> _moviesCollection;
        private Dictionary<int, List<int>> movieData;



        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewsCollection;
        }



        public IEnumerable<Movie> getAllMovies()
        {
            return _moviesCollection;
        }



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
                        allReviews.Add(review);  {
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
                    }
                    _reviewsCollection = allReviews;
                }
                movieData = moviedic;
                List<Movie> avgList = new List<Movie>();
                foreach (var dicMovie in movieData)
                {
                    int sum = dicMovie.Value.Sum();
                    double Avg = sum / dicMovie.Value.Count;
                    Avg = Math.Round(Avg, 2);
                    avgList.Add(new Movie { MovieId = dicMovie.Key, AvgRating = Avg });
                }
                _moviesCollection = avgList;
            }
        } 


    }
}