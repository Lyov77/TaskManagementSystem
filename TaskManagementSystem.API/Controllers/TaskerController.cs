using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("add")]
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

        [HttpGet("getAll/{userId}")]
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

        [HttpPut("changeStatus/{userId}/{taskerId}")]
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


        [HttpPost("deleteTask/{userId}/{taskerId}")]
        public async Task<IActionResult> DeleteAsync(string userId, Guid taskerId)
        {
            var entity = await _taskerRepository
                .GetAll(x => x.UserId == userId && x.Id == taskerId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return BadRequest("Task not found!");
            }

            entity.IsDeleted = true;
            _taskerRepository.Update(entity);
            await _repositoryManager.CommitAsync();
            return Ok();
        }


        [HttpPut("editTask/{userId}/{taskerId}")]
        public async Task<IActionResult> EditAsync(string userId, Guid taskerId, [FromBody] TaskerDto dto)
        {
            var entity = await _taskerRepository
                .GetAll(x => x.UserId == userId && x.Id == taskerId && !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return NotFound("Task not found!");
            }

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.IsCompleted = dto.IsCompleted;


            _taskerRepository.Update(entity);
            await _repositoryManager.CommitAsync();
            return Ok();
        }


    }
}
