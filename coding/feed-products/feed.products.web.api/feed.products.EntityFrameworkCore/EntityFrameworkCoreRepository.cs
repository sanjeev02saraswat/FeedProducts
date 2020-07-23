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
        DbContext ContextWrite { get; }
        DbSet<TEntity> SetWrite => ContextWrite.Set<TEntity>();

        public void Add(TEntity entity)
        {
            SetWrite.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await SetWrite.AddAsync(entity);
        }

        public void AddRange(params TEntity[] entities)
        {
            SetWrite.AddRange(entities);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await SetWrite.AddRangeAsync(entities);
        }

        public async Task AddRangeAsync(params TEntity[] entities)
        {
            await SetWrite.AddRangeAsync(entities);
        }

        public void Delete(object key)
        {
            var entity = SetWrite.Find(key);

            if (entity == null)
            {
                return;
            }

            SetWrite.Remove(entity);
        }

        public void Update(TEntity entity, object key)
        {
            var entityContext = SetWrite.Find(key);

            if (entityContext == null)
            {
                return;
            }

            ContextWrite.Entry(entityContext).CurrentValues.SetValues(entity);
        }

        public void Update(TEntity entity, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            var entityContext = SingleOrDefault(where, include);
            if (entityContext == null)
            {
                return;
            }

            ContextWrite.Entry(entityContext).CurrentValues.SetValues(entity);
        }
    }
}
