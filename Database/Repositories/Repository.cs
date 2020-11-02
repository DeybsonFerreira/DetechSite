using Database.Interfaces;
using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly EFContext context;
        public Repository(EFContext context )
        {
            this.context = context;
        }

        public TEntity Find(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public TEntity Find(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetPagination(int take, int skip)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            query = query.Skip(skip);
            query = query.Take(take);
            return query.ToList();
        }
        public IQueryable<TEntity> Query(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            return query;
        }

        public EntityEntry Entry(TEntity entity)
        {
            return context.Entry(entity);
        }

        public void Add(TEntity entity)
        {
            context.Add<TEntity>(entity);
        }

        public void Remove(TEntity entity)
        {
            context.Remove<TEntity>(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        int IRepository<TEntity>.SaveChanges()
        {
            return context.SaveChanges();
        }
        public IQueryable<TEntity> QueryAsync(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(context.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            IQueryable<TEntity> query = secondaryResult
                            .Where(spec.Criteria);

            return query;
        }

        public async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            return await QueryAsync(spec).ToArrayAsync();
        }

        private Task<TEntity[]> Exec(IQueryable<TEntity> query)
        {
            return query.ToArrayAsync();
        }
        public async Task<TEntity> FindAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> FindAsync(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FindAsync(long id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> FindAsync(ISpecification<TEntity> spec)
        {
            return await QueryAsync(spec).FirstOrDefaultAsync();
        }
        public async Task<TEntity> FindAsync(TEntity entity)
        {
            var val = entity.GetType().GetProperty("Id").GetValue(entity, null);

            return await context.Set<TEntity>().FindAsync(val);
        }

        public EFContext GetContext()
        {
            return this.context;
        }
    }
}
