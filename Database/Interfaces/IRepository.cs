using Database.Tables;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        EFContext GetContext();
        IQueryable<TEntity> Query(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        void Remove(TEntity entity);
        void Add(TEntity entity);
        Task<int> SaveChangesAsync();
        int SaveChanges();
        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec);
        IQueryable<TEntity> QueryAsync(ISpecification<TEntity> spec);
        IEnumerable<TEntity> GetPagination(int take, int skip);
        TEntity Find(int id);
        TEntity Find(Guid id);
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Guid id);
        Task<TEntity> FindAsync(TEntity entity);
        Task<TEntity> FindAsync(long id);
        Task<TEntity> FindAsync(ISpecification<TEntity> spec);
        EntityEntry Entry(TEntity entity);
    }
}
