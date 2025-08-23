using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Ê×Ò³
        /// </summary>
        /// <returns>View</returns>
        [HttpGet("/")]
        [HttpGet("index")]
        public IActionResult Index()
        {           
            return View();
        }
    }
}