using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentManagementSystem1.Models
{
    public class CustomizedValidation: ValidationAttribute
    {
        private readonly int minLength;
        private readonly int maxLength;

        public CustomizedValidation(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string stringValue)
            {
                // Trim leading spaces before checking length
                stringValue = stringValue?.TrimStart();

                if (stringValue.Replace(" ", "").Length < minLength || stringValue.Length > maxLength)
                {
                    return new ValidationResult(GetErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(string fieldName)
        {
            return $"The {fieldName} must be between {minLength} and {maxLength} characters, and leading spaces are not allowed.";
        }
    }
}
