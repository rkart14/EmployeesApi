using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class AddNumberInput : IPhoneNumberInfo
    {
        [Required]
        public int EmployeeId { get; set; }

        public int CountryCodeId { get; set; }

        public string Number { get; set; }
    }
}
