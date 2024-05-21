using TaskManagementSystem.DAL.Entities.Base;

namespace TaskManagementSystem.BLL.Abstract
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        TEntity Add(TEntity entity);
        Task DeleteAsync(TEntity entity);

    }
}
