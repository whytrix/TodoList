using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return Content("Hello");
        }
    }
}