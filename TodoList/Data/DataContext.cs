using TodoList.Enums;
using TodoList.Models;

namespace TodoList.Data
{
    public class DataContext
    {
        public static List<TodoItem> todos = new List<TodoItem>
            {
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = "学习ASP.NET Core",
                    Description = "学习ASP.NET Core的基础知识和高级特性",
                    DueDate = DateTime.Now,
                    Priority = PriorityLevel.Low,
                    IsCompleted = false
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = "完成项目报告",
                    Description = "撰写并提交项目报告",
                    DueDate = DateTime.Now,
                    Priority = PriorityLevel.High,
                    IsCompleted = true
                },
                new TodoItem
                {
                    Id = Guid.NewGuid(),
                    Title = "学习SQL",
                    Description = "学习SQL的基础知识",
                    DueDate = DateTime.Now.AddDays(2),
                    Priority = PriorityLevel.Medium,
                    IsCompleted = false
                }
            };
    }
}
