using Abp.EntityFrameworkCore;
using EmployeesApi.Entities;
using EmployeesApi.EntityFrameworkCore;
using EmployeesApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApi.Repositories
{
    public class EmployeeRepository : EmployeesApiRepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly EmployeesApiDbContext _dbContext;

        public EmployeeRepository(IDbContextProvider<EmployeesApiDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }

        public async Task InsertAllAsync(IEnumerable<Employee> employees)
        {

            await _dbContext.Employees.AddRangeAsync(employees);
        }
    }
}
