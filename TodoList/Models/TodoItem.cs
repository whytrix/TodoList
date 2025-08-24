using System.ComponentModel.DataAnnotations;
using TodoList.Attributes;
using TodoList.Enums;

namespace TodoList.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public PriorityLevel Priority { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}