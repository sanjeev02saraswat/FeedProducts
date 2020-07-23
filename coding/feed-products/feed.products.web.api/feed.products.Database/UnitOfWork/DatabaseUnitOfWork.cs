using feed.products.Database.Context;
using feed.products.Database.Repostries;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Database.UnitOfWork
{
    public class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        public DatabaseUnitOfWork(IFeedRepository feed)
        {
            Feed = feed;
        }

        DatabaseContext Context { get; set; }

        public void DiscardChanges()
        {
            if (Context == null)
            {
                return;
            }

            Context.Dispose();
            Context = null;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public IFeedRepository Feed { get;  }
    }
}
