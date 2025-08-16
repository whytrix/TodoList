using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoController : BaseController
    {
        [HttpPost("create")]
        public IActionResult DoCreate(TodoItem todoItem)
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
                return Json(todoItem);
            }
        }
    }
}