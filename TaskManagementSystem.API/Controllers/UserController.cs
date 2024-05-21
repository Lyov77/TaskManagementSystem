using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
