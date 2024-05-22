using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementSystem.Core.ViewModel;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientService httpClientService)
        {
            _logger = logger;
            this._httpClientService = httpClientService;
        }

        public IActionResult Index()
        {
            var userId = User?.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            ViewBag.UserId = userId; 
            
            return View(userId);

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var userId = Guid.Parse(User?.Claims.First().Value);
            var result = await _httpClientService.GetAll(userId.ToString());
            return View(result);
        }
    }
}
