using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BLL.Abstract;
using TaskManagementSystem.Core.ViewModel;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class TaskerController : Controller
    {
        private readonly ITaskerRepository _taskerRepository;

        public TaskerController(ITaskerRepository taskerRepository)
        {
            _taskerRepository = taskerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAll()
        {
            var taskers = _taskerRepository.GetAll();
            return Ok(taskers);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync(TaskerViewModel taskerViewModel)
        {
            Tasker tasker = new Tasker()
            {
                Title = taskerViewModel.Title,
                Description = taskerViewModel.Description,
                IsCompleted = taskerViewModel.IsCompleted,
            };

            if (ModelState.IsValid)
            {
                await _taskerRepository.AddAsync(tasker);

                return Ok(tasker);
            }

            return NotFound("Task NOT added!");
        }

        [HttpPost]
        [Route("MarkAsCompleted")]
        public async Task<IActionResult> MarkAsCompleted([FromBody] Guid taskerId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedTasker = await _taskerRepository.MarkAsCompleted(taskerId);

                    return Ok(updatedTasker);
                }
                catch (ArgumentNullException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("UpdateTask/{taskId}")]
        public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] TaskerViewModel taskerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _taskerRepository.UpdateAsync(taskId, taskerViewModel);

                if (result == null)
                    return NotFound($"Task with ID {taskId} not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the task: {ex.Message}");
            }
        }


    }
}
