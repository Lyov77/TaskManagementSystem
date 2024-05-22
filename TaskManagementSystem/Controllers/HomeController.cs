using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            var userId = User?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
       
            if (userId == null)
            {
               return View();
            }

            return RedirectToAction("Index", "Tasker");
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

       
    }
}
