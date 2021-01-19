using Abp.Application.Services;

namespace EmployeesApi
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class EmployeesApiAppServiceBase : ApplicationService
    {
        protected EmployeesApiAppServiceBase()
        {
            LocalizationSourceName = EmployeesApiConsts.LocalizationSourceName;
        }
    }
}