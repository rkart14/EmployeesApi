using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class EditNumberInput : IPhoneNumberInfo
    {
        public int EmployeeId { get; set; }

        public string Number { get; set; }

        public int CountryCodeId { get; set; }

        public int NumberId { get; set; }
    }
}
