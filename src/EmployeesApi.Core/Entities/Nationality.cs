using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeesApi.Entities
{
    public class Nationality : Entity
    {
        public Nationality(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
