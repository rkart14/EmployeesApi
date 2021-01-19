using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Timing;
using EmployeesApi.Common.Dto;
using EmployeesApi.Entities;
using EmployeesApi.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class CreateEmployeeInput : IEmployeeBasicInfo
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PersonalNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int NationalityId { get; set; }

        public int? SalaryCurrencyId { get; set; }

        public double? SalaryAmount { get; set; }

        public List<CreatePhoneNumberInput> PhoneNumbers { get; set; }

    }
}
