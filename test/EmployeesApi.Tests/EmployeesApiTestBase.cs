using System;
using System.Threading.Tasks;
using Abp.TestBase;
using EmployeesApi.EntityFrameworkCore;
using EmployeesApi.Tests.TestDatas;

namespace EmployeesApi.Tests
{
    public class EmployeesApiTestBase : AbpIntegratedTestBase<EmployeesApiTestModule>
    {
        public EmployeesApiTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<EmployeesApiDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<EmployeesApiDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<EmployeesApiDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<EmployeesApiDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<EmployeesApiDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<EmployeesApiDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<EmployeesApiDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<EmployeesApiDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
