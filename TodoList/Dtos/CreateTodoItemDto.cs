using System.ComponentModel.DataAnnotations;
using TodoList.Attributes;
using TodoList.Enums;

namespace TodoList.ViewModels
{
    public class CreateTodoItemDto
    {
        [Display(Name = "标题")]
        [Required(ErrorMessage = "{0}不能为空")]
        [MaxLength(100, ErrorMessage = "{0}长度不能超过100个字符")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "描述")]
        [MaxLength(500, ErrorMessage = "{0}长度不能超过500个字符")]
        public string? Description { get; set; }

        [Display(Name = "截止日期")]
        [DataType(DataType.Date, ErrorMessage = "{0}不是有效的日期格式")]
        [FutureDate]
        public DateTime? DueDate { get; set; }

        [Display(Name = "优先级")]
        [Required(ErrorMessage = "请选择{0}")]
        public PriorityLevel Priority { get; set; }
    }
}
