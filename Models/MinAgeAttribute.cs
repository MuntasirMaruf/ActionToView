﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ActionToView.Validators
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int minAge;

        public MinAgeAttribute(int ma)
        {
            minAge = ma;
            ErrorMessage = $"Age must be at least {minAge} years old.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date of Birth is required.");
            }

            if (DateTime.TryParse(value.ToString(), out DateTime dob))
            {
                int age = DateTime.Today.Year - dob.Year;

                if (dob.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                if (age >= minAge)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            else
            {
                return new ValidationResult("Invalid date format.");
            }
        }
    }
}
