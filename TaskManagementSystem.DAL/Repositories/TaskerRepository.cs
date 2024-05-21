using TaskManagementSystem.BLL.Repositories;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.DAL.Context;
using TaskManagementSystem.DAL.Repositories.Base;

namespace TaskManagementSystem.DAL.Repositories
{
    public class TaskerRepository : RepositoryBase<Tasker>, ITaskerRepository
    {
        public TaskerRepository(TaskerApplicationDbContext context) : base(context)
        {
        }
    }
}
