using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeesApi.Entities
{
    public class Salary : Entity
    {
        private const double MinSalaryValue = 0.00;

        [Range(MinSalaryValue, double.MaxValue)]
        public double? Amount { get; set; }

        public int? CurrencyId { get; set; }

        public Currency Currency { get; set; }
    }
}
