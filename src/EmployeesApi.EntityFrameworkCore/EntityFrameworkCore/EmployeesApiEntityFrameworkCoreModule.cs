using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeesApi.Entities;

namespace EmployeesApi.EntityFrameworkCore
{
    [DependsOn(
        typeof(EmployeesApiCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class EmployeesApiEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeesApiEntityFrameworkCoreModule).GetAssembly());
        }
    }
}