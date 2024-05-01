using System.ComponentModel.DataAnnotations;

namespace COMP_.Validation
{
    public class ContainsSymbols : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var text = value as string;
            if (text.Contains(",") || text.Contains(";") || text.Contains(":") || text.Contains("!") || text.Contains("?") || text.Contains(" "))
            {
                return new ValidationResult($"The given field should not contain such character: (!), (;), (?)");
            }
            return ValidationResult.Success;
        }
    }
}
