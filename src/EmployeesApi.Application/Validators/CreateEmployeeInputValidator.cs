using FluentValidation;
using EmployeesApi.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Validators
{
    public class CreateEmployeeInputValidator : EmployeeBasicInfoValidator<CreateEmployeeInput>
    {

        public CreateEmployeeInputValidator() { 
            RuleFor(x => x.NationalityId).NotNull().WithMessage("No Nationality provided!");
        }
    }
}
