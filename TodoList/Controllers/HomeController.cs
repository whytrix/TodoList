using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}