using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HomeWork2.CustomValidatior;

namespace HomeWork2.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name can not be empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be consist of at least 3 and at most of 50 characters")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Unsupported character in Name")]
        public string Name { get; set; }
        [Required]
        [IdValidator]
        public string Id { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailValidator]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain at least one Uppercase one lower case one special character and one number ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm passowrd field sould not be empty")]
        [Compare("Password", ErrorMessage = "Password dosen't match")]
        public string ConfPassword { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [DobValidator]
        public string Dob { get; set; }
    }
}
