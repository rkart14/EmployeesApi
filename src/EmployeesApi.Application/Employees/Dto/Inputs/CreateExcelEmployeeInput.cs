using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Employees.Dto.Inputs
{
    public class CreateExcelEmployeeInput
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public string BirthDate { get; set; }

        public string NationalityName { get; set; }
        
        public double? SalaryAmount { get; set; }

        public string SalaryCurrencyCode { get; set; }

        public string PhoneNumbersString { get; set; }
    }
}
