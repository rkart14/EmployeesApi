using EmployeesApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.EntityConfigurations
{
    class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("Salaries");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Amount);
            builder.Property(p => p.CurrencyId);

            builder.HasOne(s => s.Currency)
                .WithMany()
                .HasForeignKey("CurrencyId");
        }
    }
}
