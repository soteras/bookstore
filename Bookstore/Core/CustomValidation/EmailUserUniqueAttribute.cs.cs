using Bookstore.Infrastructure.Repository.Interface;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.CustomValidation
{
    public class EmailUserUniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repository = (IUserRepository)validationContext.GetService(typeof(IUserRepository));
            var entity = repository.GetUserByEmail(value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(string email)
        {
            return $"Email {email} já está em uso.";
        }
    }
}
