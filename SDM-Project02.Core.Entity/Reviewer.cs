using System;
using System.Collections.Generic;

namespace SDM_Project.Core.Entity
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public List<Review> ReviewersReviews { get; set; }
    }
}
