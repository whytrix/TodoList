using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult DoCreate(CreateTodoItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var err in value.Errors)
                    {
                        errors.Add(err.ErrorMessage);

                        // 如果有多个错误信息，取第一个
                        break;
                    }
                }
                return BadRequest(string.Join("\n", errors));
            }
            else
            {
                return Json(new TodoItem()
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Description = model.Description,
                    DueDate = model.DueDate,
                    Priority = model.Priority
                });
            }
        }
    }
}