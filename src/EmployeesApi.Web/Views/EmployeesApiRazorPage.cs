using Abp.AspNetCore.Mvc.Views;

namespace EmployeesApi.Web.Views
{
    public abstract class EmployeesApiRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected EmployeesApiRazorPage()
        {
            LocalizationSourceName = EmployeesApiConsts.LocalizationSourceName;
        }
    }
}
