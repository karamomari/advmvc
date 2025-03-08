using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection; // مهم لاستخدام الـ DI
using System.Linq;

namespace AdvProject.Models
{
    public class UniqueName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string newName = value.ToString();
            // الحصول على `ITIContext` باستخدام Dependency Injection
            //هيك بعمل Injection 
            //عشان اجيب كلاس الداتا بيز بدل ما اضل اعمل كريت ويوخذ ريورس ووقت عالفاضي 
            var context = validationContext.GetService<ITIContext>();

            if (context == null)
            {
                throw new InvalidOperationException("Database context is not available.");
            }
            var employee = validationContext.ObjectInstance as Employee;

            bool nameExists = context.Employees.Any(e => e.Name == newName && e.Id != employee.Id);
            if (nameExists)
            {
                return new ValidationResult("⚠️ Name Must be Unique.");
            }

            return ValidationResult.Success;
        }
    }
}
