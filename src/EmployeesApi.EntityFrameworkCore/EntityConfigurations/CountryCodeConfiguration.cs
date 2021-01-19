using EmployeesApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.EntityConfigurations
{
    public class CountryCodeConfiguration : IEntityTypeConfiguration<CountryCode>
    {
        public void Configure(EntityTypeBuilder<CountryCode> builder)
        {
            builder.ToTable("CountryCodes");

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
