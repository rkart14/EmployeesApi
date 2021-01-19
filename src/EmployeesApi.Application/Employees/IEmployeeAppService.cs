using Abp.Application.Services;
using EmployeesApi.Employees.Dto;
using EmployeesApi.Employees.Dto.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApi.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<EmployeeDto> GetAsync(GetEmployeeInput input);
        Task<List<EmployeeDto>> GetAllAsync(GetEmployeesInput input);
        Task Create(CreateEmployeeInput input);

        Task CreateList(List<CreateExcelEmployeeInput> input);
        Task Update(UpdateEmployeeInput input);
        Task EditNumber(EditNumberInput input);
    }
}
