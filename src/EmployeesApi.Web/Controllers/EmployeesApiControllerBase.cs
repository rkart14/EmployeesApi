using Abp.AspNetCore.Mvc.Controllers;

namespace EmployeesApi.Web.Controllers
{
    public abstract class EmployeesApiControllerBase: AbpController
    {
        protected EmployeesApiControllerBase()
        {
            LocalizationSourceName = EmployeesApiConsts.LocalizationSourceName;
        }
    }
}