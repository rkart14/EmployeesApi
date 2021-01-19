using Abp.Application.Services.Dto;
using EmployeesApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class EmployeeDto : EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; }

        public double? SalaryAmount { get; set; }

        public string SalaryCurrencyCode { get; set; }

        public List<PhoneNumberDto> PhoneNumbers {get;set;} 
    }
}
