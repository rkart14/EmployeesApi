using FluentValidation;
using EmployeesApi.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesApi.Validators
{
    public abstract class PhoneNumberBasicInfoValidator<T>: AbstractValidator<T> where T : IPhoneNumberInfo
    {
        public PhoneNumberBasicInfoValidator()
        {
            RuleFor(x => x.Number)
              .Must(x=> !string.IsNullOrEmpty(x)).WithMessage("No number provided!")
              .Must(x => x != null ? x.All(char.IsDigit) : true).WithMessage("Phone number contains only digits!");
            RuleFor(x => x.CountryCodeId)
                .NotNull().NotEmpty().WithMessage("No Country code provided!");
        }
    }
}
