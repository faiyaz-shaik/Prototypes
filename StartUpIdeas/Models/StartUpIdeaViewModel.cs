using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StartUpIdeas.Models
{
    public class StartUpIdeaViewModel
    {
        [Required]
        [Display(Name = "Project Name" )]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string ProjectDescription { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}