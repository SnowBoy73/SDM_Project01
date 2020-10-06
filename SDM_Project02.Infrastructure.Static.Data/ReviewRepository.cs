using System;
using System.Collections.Generic;
using SDM_Project.Core.Entity;
using SDM_Project.Core.DomainService;
using Newtonsoft.Json;
using System.IO;


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



        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewsCollection;
        }




        public void GetReviewsFromFile(string _path)
        {
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var allReviews = new List<Review>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Review review = serializer.Deserialize<Review>(reader);
                        allReviews.Add(review);
                    }

                }
                _reviewsCollection = allReviews;
            }
        }

     
    }



}