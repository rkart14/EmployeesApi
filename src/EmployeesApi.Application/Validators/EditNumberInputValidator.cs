using FluentValidation;
using EmployeesApi.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesApi.Validators
{
    public class EditNumberInputValidator : PhoneNumberBasicInfoValidator<EditNumberInput>
    {
        public EditNumberInputValidator()
        {
            RuleFor(x => x.NumberId)
                .NotNull().NotEmpty().WithMessage("No number choosen to edit!");
        }
    }
}
