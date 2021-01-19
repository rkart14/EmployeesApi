using System;
using Abp.Timing;
using EmployeesApi.Entities;
using EmployeesApi.EntityFrameworkCore;

namespace EmployeesApi.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly EmployeesApiDbContext _context;

        public TestDataBuilder(EmployeesApiDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
            _buildDataForEmployeeService(_context);
            _buildDataForLookupService(_context);
            _context.SaveChanges();
        }

        private void _buildDataForEmployeeService(EmployeesApiDbContext context)
        {
            var nationality = new Nationality("russian");
            _context.Nationalities.Add(nationality);

            _context.AddRange(
                new Employee("tyson", " fury", "01019078123", Clock.Now, nationality.Id),
                new Employee("Deontay", "Wilder", "testPersonalNumber", Clock.Now, nationality.Id)
                );
        }

        private void _buildDataForLookupService(EmployeesApiDbContext context)
        {
            var countryCode = new CountryCode("+995");
            _context.Add(countryCode);

            var currencyGel = new Currency("gel");
            var currencyUsd = new Currency("usd");
            _context.Currencies.Add(currencyGel);
            _context.Currencies.Add(currencyUsd);

            var nationalityGeo = new Nationality("georgian");
            var nationalityUsa = new Nationality("american");
            _context.Nationalities.Add(nationalityGeo);
            _context.Nationalities.Add(nationalityUsa);// plus one is added in employee service data builder
        }
    }
}