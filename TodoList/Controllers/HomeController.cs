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
                    Title = "ѧϰASP.NET Core",
                    Description = "ѧϰASP.NET Core�Ļ���֪ʶ�͸߼�����",
                    DueDate = DateTime.Now.AddDays(7),
                    Priority = PriorityLevel.High,
                    IsCompleted = false
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = "�����Ŀ����",
                    Description = "׫д���ύ��Ŀ����",
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
                return NotFound("ID����Ϊ��");
            }

            if (!Guid.TryParse(id, out Guid todoId))
            {
                return BadRequest("��Ч��ID��ʽ");
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

                        // ����ж��������Ϣ��ȡ��һ��
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