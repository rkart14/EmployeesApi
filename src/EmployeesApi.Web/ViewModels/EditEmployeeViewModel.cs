using EmployeesApi.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Web.ViewModels
{
    public class EditEmployeeViewModel
    {
        public LookupInfo LookUpInfo { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}
