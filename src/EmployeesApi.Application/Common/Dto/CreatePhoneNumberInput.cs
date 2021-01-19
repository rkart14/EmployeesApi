using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EmployeesApi.Common.Dto
{
    public class CreatePhoneNumberInput : ICustomValidate
    {
        public int? CountryCodeId { get; set; }

        public string Number { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
           
            var countryCodeHasValue = CountryCodeId.HasValue;
            var numberHasValue = !string.IsNullOrEmpty(Number);
            var bothOrNone = ((countryCodeHasValue && numberHasValue) || (!countryCodeHasValue && !numberHasValue));
            if (!bothOrNone)
            {
                context.Results.Add(new ValidationResult("Country code and number should be both provided when attaching phonenumber to employee!"));
            }
            if (countryCodeHasValue && numberHasValue)
            {
                if (!Number.All(char.IsDigit))
                    context.Results.Add(new ValidationResult("Number should contain only digits!"));
            }
        }
    }
}
