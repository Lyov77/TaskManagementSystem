using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Core.ViewModel;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Controller]
    public class TaskerController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        public TaskerController(IHttpClientService httpClientService)
        {
            this._httpClientService = httpClientService;
        }


        public async Task<IActionResult> Index()
        {
            var userId = Guid.Parse(User?.Claims.First().Value);
            var result = await _httpClientService.GetAll(userId.ToString()); // get userId and return all tasks of the user

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskerDto createTaskerDto)
        {
            var taskerViewModel = new TaskerViewModel
            {
                Id = Guid.NewGuid(),
                Title = createTaskerDto.Title,
                Description = createTaskerDto.Description,
            };

            if (!ModelState.IsValid)
            {
                return View(taskerViewModel);
            }

            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            createTaskerDto.UserId = userId;

            await _httpClientService.AddAsync(createTaskerDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ChangeStatus(Guid taskerId)
        {
            try
            {
                var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);

                await _httpClientService.ChangeStatusAsync(userId, taskerId);

                var task = await _httpClientService.GetByIdAsync(taskerId);
                string status = task.IsCompleted ? "Completed" : "Incompleted";
                TempData["Message"] = $"Status of Task '{task.Title}' is changed to {status}.";
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the tasker. Please try again.");

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid taskerId)
        {
            try
            {
                var task = await _httpClientService.GetByIdAsync(taskerId);
                var taskerViewModel = new TaskerViewModel
                {
                    Id = taskerId,
                    Title = task.Title,
                    Description = task.Description
                };
                return View(taskerViewModel);
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", "An error occurred while fetching task details.");
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Guid taskerId, TaskerDto TaskerDto)
        {

            var taskerViewModel = new TaskerViewModel
            {
                Id = taskerId,
                Title = TaskerDto.Title,
                Description = TaskerDto.Description,
            };

            if (!ModelState.IsValid)
            {
                return View(taskerViewModel);
            }

            try
            {
                var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
                var task = await _httpClientService.GetByIdAsync(taskerId);
                TempData["Message"] = $"Task '{task.Title}' is edited.";

                await _httpClientService.EditAsync(userId, taskerId, TaskerDto);
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the tasker. Please try again.");
                return View(taskerViewModel);
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid taskerId)
        {
            try
            {
                var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);

                var task = await _httpClientService.GetByIdAsync(taskerId);

                TempData["Message"] = $"Task '{task.Title}' is deleted.";

                await _httpClientService.DeleteAsync(userId, taskerId);

                return RedirectToAction("Index");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the tasker. Please try again.");

                return RedirectToAction("Index");
            }
        }
    }
}
