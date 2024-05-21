using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using TaskManagementSystem.BLL.Repositories;
using TaskManagementSystem.BLL.Repositories.Base;
using TaskManagementSystem.Core.DTOs;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]

    public class TaskerController : ControllerBase
    {
        private readonly ITaskerRepository _taskerRepository;
        private readonly IRepositoryManager _repositoryManager;

        public TaskerController(
            ITaskerRepository taskerRepository,
            IRepositoryManager repositoryManager)
        {
            _taskerRepository = taskerRepository;
            _repositoryManager = repositoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateTaskerDto dto)
        {
            var entity = new Tasker
            {
                UserId = dto.UserId,
                Title = dto.Title,
                Description = dto.Description,
            };

            _taskerRepository.Add(entity);
            await _repositoryManager.CommitAsync();
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<TaskerDto[]>> GetAllAsync([FromRoute] string userId)
        {
            var taskers = await _taskerRepository
                .GetAll(x => x.UserId == userId && !x.IsDeleted)
                .Select(x => new TaskerDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    IsCompleted = x.IsCompleted,
                })
                .ToArrayAsync();

            return Ok(taskers);
        }

        [HttpPut("status/{userId}/{taskerId}")]
        public async Task<IActionResult> ChangeStatusAsync(string userId, Guid taskerId)
        {
            var entity = await _taskerRepository
                .GetAll(x => x.UserId == userId && x.Id == taskerId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return BadRequest("Task not found!");
            }

            entity.IsCompleted = !entity.IsCompleted;
            _taskerRepository.Update(entity);
            await _repositoryManager.CommitAsync();
            return Ok();
        }

    }
}
