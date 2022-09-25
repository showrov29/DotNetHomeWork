using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeWork2.CustomValidatior
{
    public class IdValidator:ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string id = value.ToString();
                string[] segments = id.Split('-');
                int ab = int.Parse(segments[0]);
                int f = int.Parse(segments[2]);
                if (segments.Length == 3)
                {
                    if (ab >= 12 && ab <= 23)
                    {
                        if (segments[1].Length == 5)
                        {
                            if (f >= 1 && f <= 3)
                            {
                                return ValidationResult.Success;

                            }
                        }
                    }


                }






            }
            return new ValidationResult("Invalid Id");

        }


    }
}