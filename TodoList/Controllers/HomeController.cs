using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// ��ҳ
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