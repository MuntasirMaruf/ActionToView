using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ActionToView.Validators
{
    public class CustomEmailAttribute : ValidationAttribute
    {
        private readonly string idPropertyName;

        public CustomEmailAttribute(string ip)
        {
            idPropertyName = ip;
            ErrorMessage = "Email must be in the format XX-XXXXX-X@student.aiub.edu and match the ID.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) // here value is the email from the input field
        {
            var idProperty = validationContext.ObjectType.GetProperty(idPropertyName);  // here we are getting the ID property from the model
            if (idProperty == null)
            {
                return new ValidationResult($"Property '{idPropertyName}' not found.");
            }

            var idValue = idProperty.GetValue(validationContext.ObjectInstance)?.ToString();   // here we are getting the value of the ID property
            var emailValue = value?.ToString();    // here we are getting the value of the email property

            if (string.IsNullOrEmpty(idValue) || string.IsNullOrEmpty(emailValue))
            {
                return new ValidationResult("ID and Email are required.");
            }

            if (Regex.IsMatch(idValue, @"^\d{2}-\d{5}-[1-3]$"))
            {
                string expectedEmail = $"{idValue}@student.aiub.edu";

                return emailValue.Equals(expectedEmail, StringComparison.OrdinalIgnoreCase)
                    ? ValidationResult.Success
                    : new ValidationResult(ErrorMessage);
            }

            return new ValidationResult("Invalid Id.");

        }
    }
}
