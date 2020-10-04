using System;
using System.Collections.Generic;
using SDM_Project01.Core.DomianService;
using SDM_Project01.Core.Entity;

namespace SDM_Project01.Infrastructure.Static.Data
{
    public class Repository : IRepository
    {
       List<Review> reviews;
    
       public Repository()
        {
            reviews = new List<Review>();
        }


        public IEnumerable<Review> GetAllReviews()
        {
            return new List<Review>(reviews);
        }
    }

}
