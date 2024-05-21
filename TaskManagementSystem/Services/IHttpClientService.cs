using TaskManagementSystem.Core.ViewModel;

namespace TaskManagementSystem.Services
{
    public interface IHttpClientService
    {
        public Task<List<TaskerViewModel>> GetAll(string userId);
    }
}
