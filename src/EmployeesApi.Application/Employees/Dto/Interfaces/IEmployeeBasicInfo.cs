using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public interface IEmployeeBasicInfo
    {
        [Required]
         string FirstName { get; set; }

        [Required]
         string LastName { get; set; }

        [Required]
        string PersonalNumber { get; set; }

        [Required]
         DateTime BirthDate { get; set; }

        double? SalaryAmount { get; set; }
    }
}
