using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeesApi.Entities
{
    public class CountryCode : Entity
    {
        public CountryCode(string code)
        {
            Code = code;
        }
        [Required]
        public string Code { get; set; }
    }
}
