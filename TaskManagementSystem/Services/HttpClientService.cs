using TaskManagementSystem.Core.ViewModel;

namespace TaskManagementSystem.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly swagger_clientClient _client;

        public HttpClientService(IConfiguration configuration)
        {
            var baseUrl = configuration["Base_Api_Url"]
                ?? throw new Exception("Base api url is missing!");

            _client = new swagger_clientClient(baseUrl, new HttpClient());
        }

        public async Task<TaskerViewModel> GetByIdAsync(Guid taskerId)
        {
           var dto = await _client.GetAsync(taskerId);

            if (dto == null)
            {
                return null; // Return null if the tasker with the given ID is not found
            }

            var result = new TaskerViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted
            };

            return result;
        }

        public async Task<List<TaskerViewModel>> GetAll(string userId)
        {
            var dtos = await _client.GetAllAsync(userId);

            var result = dtos.Select(x => new TaskerViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
            }).ToList();

            return result;
        }

        public async Task ChangeStatusAsync(string userId, Guid taskerId)
        {
            await _client.ChangeStatusAsync(userId, taskerId);
        }

        public async Task EditAsync(string userId, Guid taskerId, TaskerDto tasker)
        {
            await _client.EditTaskAsync(userId, taskerId, tasker);
        }

        public async Task DeleteAsync(string userId, Guid taskerId)
        {
            await _client.DeleteTaskAsync(userId, taskerId);
        }

        public async Task AddAsync(CreateTaskerDto createTaskerDto)
        {
            await _client.AddAsync(createTaskerDto);
        }
    }
}
