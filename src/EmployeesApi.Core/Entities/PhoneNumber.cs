using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeesApi.Entities
{
    public class PhoneNumber : Entity
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public int CountryCodeId { get; set; }

        public CountryCode CountryCode { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
