using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeesApi.Entities;
using EmployeesApi.Localization;

namespace EmployeesApi
{
    public class EmployeesApiCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            EmployeesApiLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeesApiCoreModule).GetAssembly());
        }
    }
}