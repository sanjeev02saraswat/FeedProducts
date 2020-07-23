using feed.products.Database.Context;
using feed.products.EntityFrameworkCore;
using feed.products.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Database.Repostries
{
    public class FeedRepository : EntityFrameworkCoreRepository<FeedEntity>, IFeedRepository
    {
        public FeedRepository(DatabaseContext contextWrite):base(contextWrite)
        {

        }
    }
}
