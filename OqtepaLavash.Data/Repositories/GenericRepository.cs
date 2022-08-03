
using Microsoft.EntityFrameworkCore;
using OqtepaLavash.Data.Contexts;
using OqtepaLavash.Data.IRepositories;
using System.Linq.Expressions;

namespace OqtepaLavash.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
#pragma warning disable
        private readonly OqtepaDbContext dbContext;

        public GenericRepository()
        {
            dbContext = new OqtepaDbContext();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            TEntity source = dbContext.Set<TEntity>().Add(entity).Entity;
            await dbContext.SaveChangesAsync();
            return source;
        }

        public async Task<Boolean> DeleteAsync(Expression<Func<TEntity, Boolean>> predicate)
        {
            TEntity entity = await GetAsync(predicate);

            if (entity is null)
                return false;
            
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, Boolean>> predicate = null)
            => predicate is null ? dbContext.Set<TEntity>() : dbContext.Set<TEntity>().Where(predicate);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, Boolean>> predicate)
            => await dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity source = dbContext.Update(entity).Entity;
            await dbContext.SaveChangesAsync();

            return source;
        }
    }
}
