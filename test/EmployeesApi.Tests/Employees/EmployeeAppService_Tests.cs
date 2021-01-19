using Abp.Runtime.Validation;
using Abp.Timing;
using EmployeesApi.Employees;
using EmployeesApi.Employees.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApi.Tests.Employees
{
    public class EmployeeAppService_Tests : EmployeesApiTestBase
    {
        private readonly IEmployeeAppService _employeeAppService;
        public EmployeeAppService_Tests()
        {
            _employeeAppService = Resolve<IEmployeeAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Employees()
        {
            //Act
            var output = await _employeeAppService.GetAllAsync(new GetEmployeesInput
            {
                ItemsToFetch = 10,
                PageNumber = 1
            });

            //Assert
            output.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Should_Not_Create_New_Employee_Without_FirstName()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var fakeEmployee = getFakeCreateEmployeeInput();
                fakeEmployee.FirstName = null;
                await _employeeAppService.Create(fakeEmployee);
            });
        }

        [Fact]
        public async Task Should_Not_Create_New_Employee_Without_LastName()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var fakeEmployee = getFakeCreateEmployeeInput();
                fakeEmployee.LastName = null;
                await _employeeAppService.Create(fakeEmployee);
            });
        }

        [Fact]
        public async Task Should_Not_Create_New_Employee_Without_PersonalNumber()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var fakeEmployee = getFakeCreateEmployeeInput();
                fakeEmployee.PersonalNumber = null;
                await _employeeAppService.Create(fakeEmployee);
            });
        }

        [Fact]
        public async Task Should_Not_Create_New_Employee_Without_Invalid_BirthDate()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                var fakeEmployee = getFakeCreateEmployeeInput();
                fakeEmployee.BirthDate = Clock.Now.AddDays(5);
                await _employeeAppService.Create(fakeEmployee);
            });
        }

        private CreateEmployeeInput getFakeCreateEmployeeInput()
        {
            return new CreateEmployeeInput
            {
                FirstName = "test",
                LastName = "test",
                BirthDate= Clock.Now,
                NationalityId = 1,
                PersonalNumber = "12345"
            };
        }
    }
}
