using Abp.Domain.Repositories;
using EmployeesApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApi.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task InsertAllAsync(IEnumerable<Employee> employees);
    }
}
