using System.ComponentModel.DataAnnotations;

namespace Bledea_Aurica_Iuliana_SpitalApp.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            if (date < DateTime.Now)
            {
                return new ValidationResult("Data programarii trebuie sa fie in viitor!");
            }
            return ValidationResult.Success;
        }
    }
}