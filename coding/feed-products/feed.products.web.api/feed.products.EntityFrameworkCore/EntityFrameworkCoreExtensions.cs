using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace feed.products.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, object>>[] properties) where TEntity : class
        {
            properties?.ToList().ForEach(property => queryable = queryable.Include(property));
            return queryable;
        }
    }
}
