using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AdvProject.Models
{
    public class UniqueNameG<TEntity> : ValidationAttribute where TEntity : class
    {


        private readonly string _propertyName;

        public UniqueNameG(string propertyName)
        {

            _propertyName = propertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }

            // الحصول على `ITIContext` باستخدام Dependency Injection
            var context = validationContext.GetService<ITIContext>();
            if (context == null)
            {
                throw new InvalidOperationException("Database context is not available.");
            }

            // الحصول على الـ DbSet<TEntity> الخاص بالكيان
            var dbSet = context.Set<TEntity>();
            if (dbSet == null)
            {
                throw new InvalidOperationException($"Entity {typeof(TEntity).Name} not found in DbContext.");
            }

            // الحصول على الكائن الحالي (instance) واستخراج الـ ID الخاص به
            var entity = validationContext.ObjectInstance;
            PropertyInfo? idProperty = entity.GetType().GetProperty("Id");
            int entityId = idProperty != null ? (int)idProperty.GetValue(entity) : 0;

            // البحث عن قيمة مكررة، مع استثناء نفس الكائن من البحث
            bool exists = dbSet.Any(e =>
                EF.Property<object>(e, _propertyName).ToString() == value.ToString() &&
                EF.Property<int>(e, "Id") != entityId);

            if (exists)
            {
                return new ValidationResult($"⚠️ {_propertyName} must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
