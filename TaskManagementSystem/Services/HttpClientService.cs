using Microsoft.EntityFrameworkCore.Query.Internal;
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
    }
}
