﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using TaskManagementSystem.Core.ViewModel;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
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
            var result = await _httpClientService.GetAll(userId.ToString());
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> CreateTasker(CreateTaskerDto createTaskerDto)
        {

            if (!ModelState.IsValid)
            {
                // If model state is not valid, return the view with validation errors
                return View(createTaskerDto);
            }

            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            createTaskerDto.UserId = userId;

            var taskerViewModel = new TaskerViewModel
            {
                Id = Guid.NewGuid(),
                Title = createTaskerDto.Title,
                Description = createTaskerDto.Description,
            };

            var createTaskerDtoJson = JsonConvert.SerializeObject(taskerViewModel);


            TempData["CreateTaskerDto"] = createTaskerDtoJson;


            await _httpClientService.AddAsync(createTaskerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(Guid taskerId)
        {
            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            await _httpClientService.ChangeStatusAsync(userId, taskerId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string userId, Guid taskerId, TaskerDto taskerDto)
        {
            
            await _httpClientService.EditAsync(userId, taskerId, taskerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string userId, Guid taskerId)
        {
            await _httpClientService.DeleteAsync(userId, taskerId);
            return RedirectToAction("Index");
        }

       /* public async Task<IActionResult> ChangeCompletedStatus(CreateTaskerDto createTaskerDto)
        {

            if (!ModelState.IsValid)
            {
                // If model state is not valid, return the view with validation errors
                return View(createTaskerDto);
            }

            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            createTaskerDto.UserId = userId;

            var taskerViewModel = new TaskerViewModel
            {
                Id = Guid.NewGuid(),
                Title = createTaskerDto.Title,
                Description = createTaskerDto.Description,
            };

            var createTaskerDtoJson = JsonConvert.SerializeObject(taskerViewModel);


            TempData["CreateTaskerDto"] = createTaskerDtoJson;


            await _httpClientService.EditAsync(userId, taskerViewModel.Id, );
            return RedirectToAction("Index");
        }*/
    }
}