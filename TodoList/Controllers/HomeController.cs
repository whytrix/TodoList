using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.ViewModels;
using TodoList.Enums;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {

        private static List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = "学习ASP.NET Core",
                    Description = "学习ASP.NET Core的基础知识和高级特性",
                    DueDate = DateTime.Now.AddDays(7),
                    Priority = PriorityLevel.High,
                    IsCompleted = false
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = "完成项目报告",
                    Description = "撰写并提交项目报告",
                    DueDate = DateTime.Now.AddDays(3),
                    Priority = PriorityLevel.Medium,
                    IsCompleted = true
                }
            };

        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(todoItems);
        }

        [HttpGet("Details/{id}")]
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound("ID不能为空");
            }

            if (!Guid.TryParse(id, out Guid todoId))
            {
                return BadRequest("无效的ID格式");
            }

            var todoItem = todoItems.FirstOrDefault(t => t.Id == todoId);
            return View(todoItem);
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