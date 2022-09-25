using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWork2.CustomValidatior
{
    public class DobValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime dob = DateTime.Parse(value.ToString());
                var bd = new DateTime(2022, 1, 1);
                int age = (int)((bd - dob).TotalDays / 365.24);
                if (age >= 18)
                {
                    return ValidationResult.Success;

                }
               

            }
            return new ValidationResult("Age is under 18");
        }
    }
}