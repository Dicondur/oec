using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DCClassLibrary
{
    public class DCDateNotInFutureAttribute : ValidationAttribute
    {
        public CheckDate(string inp)
        {

        }


        //public PostalCodeAttribute()
        //{
        //    ErrorMessage = "{0} does not match the Canadian postal code pattern: A3A 3A3";
        //}


        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    Regex pattern = new Regex(@"^[a-z]\d[a-z] ?\d[a-z]\d$", RegexOptions.IgnoreCase);
        //    if (value == null || value.ToString() == "" || pattern.IsMatch(value.ToString()))
        //        return ValidationResult.Success;

        //    return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        //}

    }
}
