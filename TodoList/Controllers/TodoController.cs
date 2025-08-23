using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Enums;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Route("todo")]
    public class TodoController : Controller
    {
        /// <summary>
        /// todo默认页
        /// </summary>
        /// <param name="isCompleted">是否完成</param>
        /// <returns>View</returns>
        [HttpGet("all")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取今天待完成todos
        /// </summary>
        /// <returns>PartialView</returns>
        [HttpGet("today")]
        public IActionResult Today()
        {
            IEnumerable<TodoItem> todosMatch = DataContext.todos.Where(t => t.DueDate?.Date == DateTime.Now.Date).OrderByDescending(t => t.Priority);
            return PartialView("_TodoListPartialView", todosMatch);
        }

        /// <summary>
        /// 根据条件检索todos
        /// </summary>
        /// <returns>PartialView</returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery]string? title, [FromQuery(Name = "due_date")]DateTime? dueDate, [FromQuery(Name = "is_completed")] bool? isCompleted)
        {
            IEnumerable<TodoItem> todosMatch = DataContext.todos;

            if (title != null)
            {
                todosMatch = todosMatch.Where(t => t.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }

            if (dueDate.HasValue)
            {
                todosMatch = todosMatch.Where(t => t.DueDate?.Date == dueDate?.Date);
            }

            if (isCompleted.HasValue)
            {
                todosMatch = todosMatch.Where(t => t.IsCompleted == isCompleted);
            }
            return PartialView("_TodoListPartialView", todosMatch);
        }

        /// <summary>
        /// 获取某一个todo
        /// </summary>
        /// <param name="id">TodoID</param>
        /// <returns>View</returns>
        [HttpGet("details/{id}")]
        public IActionResult Details([FromRoute] string id)
        {
            if (id == null)
            {
                return NotFound("ID不能为空");
            }

            if (!Guid.TryParse(id, out Guid todoId))
            {
                return BadRequest("无效的ID格式");
            }

            var todoItem = DataContext.todos.FirstOrDefault(t => t.Id == todoId);
            return View(todoItem);
        }

        /// <summary>
        /// 创建新的todo
        /// </summary>
        /// <param name="model">要创建的todo</param>
        /// <returns>JSON</returns>
        [HttpPost("create")]
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
