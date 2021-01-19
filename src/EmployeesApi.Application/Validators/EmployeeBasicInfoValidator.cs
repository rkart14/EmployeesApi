using Abp.Timing;
using FluentValidation;
using EmployeesApi.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Validators
{
    public abstract class EmployeeBasicInfoValidator<T> : AbstractValidator<T> where T : IEmployeeBasicInfo
    {
        public EmployeeBasicInfoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("No Firstname Provided");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("No Lastname Provided");
            RuleFor(x => x.PersonalNumber).NotNull().NotEmpty().WithMessage("No Personal number Provided");
            RuleFor(x => x.BirthDate).NotNull().NotEmpty().LessThan(Clock.Now).WithMessage("Invalid Birth Date!");
            RuleFor(x => x.SalaryAmount).Must(x => x.HasValue ? x.Value > 0 : true).WithMessage("Salary Amount should be greater than 0!");
        }
    }
}
