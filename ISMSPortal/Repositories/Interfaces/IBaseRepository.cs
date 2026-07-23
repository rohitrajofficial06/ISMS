using System.Linq.Expressions;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(object id);

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task SaveAsync();
    }
}