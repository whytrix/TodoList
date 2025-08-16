using System.ComponentModel.DataAnnotations;

namespace TodoList.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "截止日期不能早于今天";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date < DateTime.Today)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage));
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}