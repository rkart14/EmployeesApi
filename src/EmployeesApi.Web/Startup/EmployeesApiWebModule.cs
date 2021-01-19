using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeesApi.Configuration;
using EmployeesApi.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeesApi.Web.Startup
{
    [DependsOn(
        typeof(EmployeesApiApplicationModule), 
        typeof(EmployeesApiEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class EmployeesApiWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public EmployeesApiWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(EmployeesApiConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<EmployeesApiNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(EmployeesApiApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeesApiWebModule).GetAssembly());
        }
    }
}