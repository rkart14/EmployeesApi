using EmployeesApi.Entities;
using EmployeesApi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.EntityConfigurations
{
    public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.ToTable("Nationalities");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();

        }
    }
}
