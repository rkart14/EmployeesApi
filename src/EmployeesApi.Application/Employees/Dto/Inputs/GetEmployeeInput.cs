using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class GetEmployeeInput
    {
        [Required]
        public int EmployeeId { get; set; }
    }
}
