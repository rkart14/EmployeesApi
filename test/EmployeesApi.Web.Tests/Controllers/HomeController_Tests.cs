using System.Threading.Tasks;
using EmployeesApi.Web.Controllers;
using Shouldly;
using Xunit;

namespace EmployeesApi.Web.Tests.Controllers
{
    public class HomeController_Tests : EmployeesApiWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }

    }
}
