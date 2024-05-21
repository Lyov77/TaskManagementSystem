using System.Linq.Expressions;
using TaskManagementSystem.Core.ViewModel;
using TaskManagementSystem.DAL.Entities;


namespace TaskManagementSystem.BLL.Abstract
{
    public interface ITaskerRepository : IRepositoryBase<Tasker>
    {
        Task<Tasker> AddAsync(Tasker tasker);
        Task<Tasker> MarkAsCompleted(Guid taskerId);
        Tasker Update(Tasker tasker);
        Task<Tasker> UpdateAsync(Guid taskId, TaskerViewModel taskerViewModel);
        Task<Tasker?> FirstOrDefaultAsync(Expression<Func<Tasker, bool>>? predicate = null);
        IQueryable<Tasker> GetAll(Expression<Func<Tasker, bool>>? predicate = null);

    }
}
