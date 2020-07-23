using feed.products.Database.Repostries;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Database.UnitOfWork
{
  public  interface IDatabaseUnitOfWork
    {
        IFeedRepository Feed { get; }
        void DiscardChanges();
        void SaveChanges();

        IDbContextTransaction BeginTransaction();
    }
}
