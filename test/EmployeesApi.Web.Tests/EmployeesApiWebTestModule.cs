using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeesApi.Web.Startup;
namespace EmployeesApi.Web.Tests
{
    [DependsOn(
        typeof(EmployeesApiWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class EmployeesApiWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeesApiWebTestModule).GetAssembly());
        }
    }
}