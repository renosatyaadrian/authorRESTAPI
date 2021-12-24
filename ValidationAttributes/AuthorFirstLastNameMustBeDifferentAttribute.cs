using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authorRESTAPI.Dtos;

namespace authorRESTAPI.ValidationAttributes
{
    public class AuthorFirstLastNameMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var author = (AuthorForUpdateDto)validationContext.ObjectInstance;
            if (author.FirstName == author.LastName)
            {
                return new ValidationResult("FirstName dan LastName tidak boleh sama", new[] {nameof(AuthorForUpdateDto)});
            }
            return ValidationResult.Success;
        }
    }
}