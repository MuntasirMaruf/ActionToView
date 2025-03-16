using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActionToView.Models
{
	public class ProjectInputModel
	{
        [Required]
        public string TitleMB { get; set; }

        [StringLength(20)]
        public string CourseMB { get; set; }

        [Required(ErrorMessage ="What the fuck dude!!")]
        public string DescriptionMB { get; set; }

    }
}