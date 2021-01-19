using EmployeesApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.CreationTime).IsRequired();
            builder.Property(p => p.NationalityId).IsRequired();
            builder.Property(p => p.PersonalNumber).IsRequired();
            builder.HasIndex(p => p.PersonalNumber).IsUnique();
            builder.Property(p => p.SalaryId);

            builder.HasOne(x => x.Salary)
                .WithMany()
                .HasForeignKey("SalaryId");

            builder.HasOne(x => x.Nationality)
                .WithMany()
                .HasForeignKey("NationalityId");
        }
    }
}
