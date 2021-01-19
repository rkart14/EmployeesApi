using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public interface IPhoneNumberInfo
    {
         int CountryCodeId { get; set; }

         string Number { get; set; }
    }
}
