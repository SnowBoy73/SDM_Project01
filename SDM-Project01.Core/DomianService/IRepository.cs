using System;
using System.Collections.Generic;
using SDM_Project01.Core.Entity;

namespace SDM_Project01.Core.DomianService
{
    public interface IRepository
    {

        IEnumerable<Review> GetAllReviews();

    }
}

