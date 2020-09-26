using System;

namespace SDM_Project01.Core.Entity
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int AssociatedMovieId { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewerId { get; set; }
    }
}
