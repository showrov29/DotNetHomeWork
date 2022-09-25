using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeWork2.CustomValidatior
{
    public class EmailValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string email=value.ToString();
                if (email.EndsWith("@student.aiub.edu"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Invalid Email");
        }
        
    }
}