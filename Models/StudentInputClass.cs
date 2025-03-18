using ActionToView.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActionToView.Models
{
	public class StudentInputClass
	{
        [Required]
        [RegularExpression(@"^[a-zA-Z\s\.\-]+$", ErrorMessage = "Only alphabets, spaces and (.dot, -dash)")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Invalid Id (XX-XXXXX-X(1-3)")]
        public string Id { get; set; }

        [Required]
        [MinAge(18)]
        public string DOB { get; set; }

        [Required]
        [CustomEmail("Id")]
        public string Email { get; set; }
    }
}