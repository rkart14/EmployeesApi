using EmployeesApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.EntityConfigurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers1");
            builder.HasKey(x => x.Id);
          
            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.CountryCodeId).IsRequired();
            builder.HasIndex(p => new { p.CountryCodeId, p.Number }).IsUnique();
            builder.HasOne(p => p.Employee)
                .WithMany(e => e.PhoneNumbers)
                .HasForeignKey("EmployeeId");
        }
    }
}
