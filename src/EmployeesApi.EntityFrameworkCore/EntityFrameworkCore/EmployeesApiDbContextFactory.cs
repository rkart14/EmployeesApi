using EmployeesApi.Configuration;
using EmployeesApi.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeesApi.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class EmployeesApiDbContextFactory : IDesignTimeDbContextFactory<EmployeesApiDbContext>
    {
        public EmployeesApiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EmployeesApiDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(EmployeesApiConsts.ConnectionStringName)
            );

            return new EmployeesApiDbContext(builder.Options);
        }
    }
}