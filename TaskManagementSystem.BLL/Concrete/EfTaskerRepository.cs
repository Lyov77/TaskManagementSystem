/*using System.Linq.Expressions;
using TaskManagementSystem.BLL.Abstract;
using TaskManagementSystem.Core.ViewModel;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.BLL.Concrete
{
    public class EfTaskerRepository : ITaskerRepository
    {
        private readonly ITaskerRepository _taskerRepository;
        private readonly IRepositoryManager _repositoryManager;

        public EfTaskerRepository(ITaskerRepository taskerRepository, IRepositoryManager repositoryManager)
        {
            _taskerRepository = taskerRepository;
            _repositoryManager = repositoryManager;

        }

        public Tasker Add(Tasker entity)
        {
            _taskerRepository.Add(entity);

            return entity;
        }

        public async Task<Tasker> AddAsync(Tasker tasker)
        {
            _taskerRepository.Add(tasker);
            await _repositoryManager.CommitAsync();

            return tasker;
        }

        public async Task DeleteAsync(Tasker entity)
        {
            var tasker = await _taskerRepository.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entity is null)
            {
                return;
            }

            entity.IsDeleted = true;
            _taskerRepository.Update(entity);
            await _repositoryManager.CommitAsync();
        }

        public Tasker Update(Tasker tasker)
        {
            _taskerRepository.Update(tasker);
            return tasker;
        }

        public async Task<Tasker> UpdateAsync(Guid taskId, TaskerViewModel taskerViewModel)
        {
            var task = await _taskerRepository.FirstOrDefaultAsync(x => x.Id == taskId);

            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            task.Title = taskerViewModel.Title;
            task.Description = taskerViewModel.Description;
            task.IsCompleted = taskerViewModel.IsCompleted;

            _taskerRepository.Update(task);
            await _repositoryManager.CommitAsync();

            return task;

        }

        public async Task<Tasker?> FirstOrDefaultAsync(Expression<Func<Tasker, bool>>? predicate = null)
        {
            if (predicate != null)
            {
                return await _taskerRepository.FirstOrDefaultAsync(predicate);
            }

            throw new ArgumentNullException(nameof(predicate));
        }

        public IQueryable<Tasker> GetAll(Expression<Func<Tasker, bool>>? predicate = null)
        {


            return _taskerRepository.GetAll(predicate);
        }

        public async Task<Tasker> MarkAsCompleted(Guid taskerId)
        {
            var tasker = await _taskerRepository.FirstOrDefaultAsync(t => t.Id == taskerId);

            ArgumentNullException.ThrowIfNull(tasker);

            tasker.IsCompleted = true;
            return _taskerRepository.Update(tasker);
        }

    }
}
*/