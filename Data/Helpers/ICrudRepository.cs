using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helpers
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAllByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByCriteriaAsync(Expression<Func<TEntity, bool>> predicate);

        Task Insert(TEntity entity);

        Task InsertBulk(List<TEntity> entities);

        Task Update(TEntity entity);

        Task UpdateBulk(List<TEntity> entities);

        Task Delete(TEntity entity);

        Task DeleteBulk(List<TEntity> entities);
    }
}
