using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ActionToView.Validators
{
    public class EmailMatchesIdAttribute : ValidationAttribute
    {
        private readonly string _idPropertyName;

        public EmailMatchesIdAttribute(string idPropertyName)
        {
            _idPropertyName = idPropertyName;
            ErrorMessage = "Email must be in the format XX-XXXXX-X@student.aiub.edu and match the ID.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) // here value is the email from the input field
        {
            var idProperty = validationContext.ObjectType.GetProperty(_idPropertyName);  // here we are getting the ID property from the model
            if (idProperty == null)
            {
                return new ValidationResult($"Property '{_idPropertyName}' not found.");
            }

            var idValue = idProperty.GetValue(validationContext.ObjectInstance)?.ToString();   // here we are getting the value of the ID property
            var emailValue = value?.ToString();    // here we are getting the value of the email property

            if (string.IsNullOrEmpty(idValue) || string.IsNullOrEmpty(emailValue))
            {
                return new ValidationResult("ID and Email are required.");
            }

            string expectedEmail = $"{idValue}@student.aiub.edu";

            return emailValue.Equals(expectedEmail, StringComparison.OrdinalIgnoreCase)
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }
    }
}
