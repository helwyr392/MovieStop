using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStop.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Must be 18 years or older to begin a membership.");
        }
    }
}