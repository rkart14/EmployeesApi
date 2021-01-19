using EmployeesApi.Employees;
using EmployeesApi.Employees.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeesApi.Web.Controllers
{
    public class HomeController : EmployeesApiControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;

        public HomeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        public async Task<ActionResult> Index(GetEmployeesInput input)
        {
            var result = await _employeeAppService.GetAllAsync(input);
            return View("GetAll",result);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}