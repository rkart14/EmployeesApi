using Abp.EntityFrameworkCore;
using EmployeesApi.Entities;
using EmployeesApi.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.EntityFrameworkCore
{
    public class EmployeesApiDbContext : AbpDbContext
    {
        public const string DefaultSchema = "HotelHubDb";

        //Add DbSet properties for your entities...
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        public EmployeesApiDbContext(DbContextOptions<EmployeesApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryCodeConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
