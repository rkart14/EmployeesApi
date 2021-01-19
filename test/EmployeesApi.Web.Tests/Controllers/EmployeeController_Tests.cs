using EmployeesApi.Employees.Dto;
using EmployeesApi.Web.Controllers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApi.Web.Tests.Controllers
{
    public class EmployeeController_Tests : EmployeesApiWebTestBase
    {
        [Fact]
        public async Task Create_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<EmployeeController>(nameof(EmployeeController.Create))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
