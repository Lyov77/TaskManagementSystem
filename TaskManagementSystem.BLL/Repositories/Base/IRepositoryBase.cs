using System.Linq.Expressions;
using TaskManagementSystem.Core.Entities.Base;

namespace TaskManagementSystem.BLL.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null, bool noTrack = false);
    }
}
