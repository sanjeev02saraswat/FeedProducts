using feed.products.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace feed.products.EntityFrameworkCore
{
    public partial class EntityFrameworkCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Queryable => SetRead.AsTracking();
        DbContext ContextRead { get; }
        DbSet<TEntity> SetRead => ContextRead.Set<TEntity>();

        protected EntityFrameworkCoreRepository(DbContext contextWrite)
        {
          
            ContextWrite = contextWrite;
            ContextWrite.ChangeTracker.AutoDetectChangesEnabled = true;
            ContextWrite.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public bool Any()
        {
            return SetRead.Any();
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return SetRead.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return SetRead.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return SetRead.AnyAsync(where);
        }

        public long Count()
        {
            return SetRead.LongCount();
        }

        public long Count(Expression<Func<TEntity, bool>> where)
        {
            return SetRead.LongCount(where);
        }

        public Task<long> CountAsync()
        {
            return SetRead.LongCountAsync();
        }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>> where)
        {
            return SetRead.LongCountAsync(where);
        }

        public TEntity FirstOrDefault(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefault();
        }

            public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefault();
        }

        public Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefaultAsync();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefaultAsync();
        }

        public TEntityResult FirstOrDefaultResult<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefault();
        }

        public Task<TEntityResult> FirstOrDefaultResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefaultAsync();
        }

        public TEntity LastOrDefault(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefault();
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefault();
        }

        public Task<TEntity> LastOrDefaultAsync(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefaultAsync();
        }

        public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefaultAsync();
        }

        public TEntityResult LastOrDefaultResult<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefault();
        }

        public Task<TEntityResult> LastOrDefaultResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefaultAsync();
        }

        public IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).ToList();
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).ToList();
        }

        public IEnumerable<TEntityResult> ListResult<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).ToList();
        }

        public PagedList<TEntity> List(PagedListParameters parameters, params Expression<Func<TEntity, object>>[] include)
        {
            return new PagedList<TEntity>(QueryableInclude(include), parameters);
        }

        public PagedList<TEntity> List(PagedListParameters parameters, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return new PagedList<TEntity>(QueryableWhereInclude(where, include), parameters);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] include)
        {
            return await QueryableInclude(include).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return await QueryableWhereInclude(where, include).ToListAsync();
        }

        public async Task<IEnumerable<TEntityResult>> ListResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return await QueryableWhereSelect(where, select).ToListAsync();
        }

        public TEntity Select(long id)
        {
            return SetRead.Find(id);
        }

        //public Task<TEntity> SelectAsync(long id)
        //{
        //    return SetRead.FindAsync(id);
        //}

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefault();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefaultAsync();
        }

        public TEntityResult SingleOrDefaultResult<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefault();
        }

        public Task<TEntityResult> SingleOrDefaultResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefaultAsync();
        }

        IQueryable<TEntity> QueryableInclude(Expression<Func<TEntity, object>>[] include)
        {
            return Queryable.Include(include);
        }

        IQueryable<TEntity> QueryableWhereInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>>[] include)
        {
            return Queryable.Where(where).Include(include);
        }

        IQueryable<TEntityResult> QueryableWhereSelect<TEntityResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntityResult>> select)
        {
            return Queryable.Where(where).Select(select);
        }
    }
}
