using CsvHelper;
using EmployeesApi.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApi.EntityFrameworkCore
{
    public class EmployeesApiContextSeed
    {
        public async Task SeedAsync(IHostingEnvironment env, EmployeesApiDbContext context)
        {
            var contentRootPath = env.ContentRootPath;

            using (context)
            {
                    context.CountryCodes
                    .AddRange(GetLookupValues(contentRootPath,"CountryCodes.csv")
                        .Select(code => new CountryCode(code))
                        .Where(x=> context.CountryCodes.FirstOrDefault(y => y.Code == x.Code) == null)
                        );
                    context.Currencies
                    .AddRange(GetLookupValues(contentRootPath, "Currencies.csv")
                        .Select(code => new Currency(code))
                        .Where(x => context.Currencies.FirstOrDefault(y=> y.Code == x.Code) == null)
                        );
                    context.Nationalities
                    .AddRange(GetLookupValues(contentRootPath, "Nationalities.csv")
                        .Select(name => new Nationality(name))
                        .Where(x => context.Nationalities.FirstOrDefault(y => y.Name == x.Name) == null)
                        );

                await context.SaveChangesAsync();
            }

        }

        private IEnumerable<string> GetLookupValues(string contentRootPath, string fileName)
        {
            List<string> result = new List<string>();
            string value;
            using (var reader = new StreamReader(Path.Combine(contentRootPath, "Setup", fileName)))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }
    }
}
