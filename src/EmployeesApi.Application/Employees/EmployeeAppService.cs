using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using EmployeesApi.Employees.Dto;
using EmployeesApi.Employees.Dto.Inputs;
using EmployeesApi.Entities;
using EmployeesApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Employees
{
    public class EmployeeAppService : EmployeesApiAppServiceBase, IEmployeeAppService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IObjectMapper _objectMapper;
        public EmployeeAppService(IRepository<Employee> employeeRepository, IObjectMapper objectMapper)
        {
            _employeeRepository = employeeRepository;
            _objectMapper = objectMapper;
        }

        public async Task<List<EmployeeDto>> GetAllAsync(GetEmployeesInput input)
        {
            var employees = await _employeeRepository
                  .GetAll()
                  .Include("Salary.Currency")
                  .Include("Nationality")
                  .Include("PhoneNumbers.CountryCode")
                  .Skip((input.PageNumber - 1) * input.ItemsToFetch)
                  .Take(input.ItemsToFetch)
                  .ToListAsync();
            return _objectMapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task Create(CreateEmployeeInput input)
        {
            var employee = _objectMapper.Map<Employee>(input);
            await _employeeRepository.InsertAsync(employee);
        }

        public async Task Update(UpdateEmployeeInput input)
        {
            var employee = await _employeeRepository.GetAsync(input.EmployeeId);
            employee.UpdateBasicInfo(input.FirstName, input.LastName, input.PersonalNumber, input.BirthDate);
            employee.NationalityId = input.NationalityId;
            if (input.SalaryCurrencyId.HasValue || input.SalaryAmount.HasValue)
            {
                var employeeSalary = new Salary
                {
                    Amount = input.SalaryAmount ?? null,
                    CurrencyId = input.SalaryCurrencyId ?? null
                };
                employee.UpdateSalary(employeeSalary);
            }
        }

        public async Task AddNumber(AddNumberInput input)
        {
            var employee = await _employeeRepository
                  .GetIncluding(e => e.Id == input.EmployeeId, "PhoneNumbers");
            var number = _objectMapper.Map<PhoneNumber>(input);
            employee.AddPhoneNumber(number);
        }

        public async Task EditNumber(EditNumberInput input)
        {
            var employee = await _employeeRepository.GetIncluding(x => x.Id == input.EmployeeId, "PhoneNumbers");
            var phoneNumber = _objectMapper.Map<PhoneNumber>(input);
            employee.EditPhoneNumber(phoneNumber);
        }

        public async Task<EmployeeDto> GetAsync(GetEmployeeInput input)
        {
            var employee = await _employeeRepository
                  .GetIncluding(e => e.Id == input.EmployeeId, "Salary.Currency", "Nationality", "PhoneNumbers");
            return _objectMapper.Map<EmployeeDto>(employee);
        }

        public async Task CreateList(List<CreateExcelEmployeeInput> input)
        {
            var employees = _objectMapper.Map<List<Employee>>(input);
            foreach(var employee in employees)
                await _employeeRepository.InsertAsync(employee);
        }
    }

    public static class IRepositoryExtension
    {
        public static async Task<T> GetIncluding<T>(this IRepository<T> repo, Expression<Func<T, bool>> filter, params string[] includes) where T : class, IEntity<int>
        {
            return await includes.
                Aggregate(repo.GetAll(), (prev, cur) => prev.Include(cur))
                .FirstAsync(filter);
        }
    }
}
