

using System.Linq.Expressions;

namespace OqtepaLavash.Data.IRepositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, Boolean>> predicate);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, Boolean>> predicate = null);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<Boolean> DeleteAsync(Expression<Func<TEntity, Boolean>> predicate);
    }
}
