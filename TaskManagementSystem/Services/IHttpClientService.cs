using TaskManagementSystem.Core.ViewModel;

namespace TaskManagementSystem.Services
{
    public interface IHttpClientService
    {
        public Task<TaskerViewModel> GetByIdAsync(Guid taskerId);
        public Task<List<TaskerViewModel>> GetAll(string userId);
        Task AddAsync(CreateTaskerDto createTaskerDto);
        Task EditAsync(string userId, Guid taskerId, TaskerDto tasker);
        Task DeleteAsync(string userId, Guid taskerId);
        Task ChangeStatusAsync(string userId, Guid taskerId);
    }
}
