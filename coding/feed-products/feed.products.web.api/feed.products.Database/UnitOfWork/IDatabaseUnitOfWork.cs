using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace feed.products.Database.UnitOfWork
{
  public  interface IDatabaseUnitOfWork
    {
        void DiscardChanges();
        void SaveChanges();

        IDbContextTransaction BeginTransaction();
    }
}
