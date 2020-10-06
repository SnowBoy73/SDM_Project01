using System;

namespace SDM_Project.Core.Entity
{
    public class Review
    {
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public int Reviewer { get; set; }
    }
}
