using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class UpdateEmployeeInput : IEmployeeBasicInfo
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

        [Required]
        public int EmployeeId { get; set; }

        public double? SalaryAmount { get; set; }

        public int? SalaryCurrencyId { get; set; }
    }
}
