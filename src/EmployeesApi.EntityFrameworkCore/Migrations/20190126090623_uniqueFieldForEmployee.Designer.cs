﻿// <auto-generated />
using System;
using EmployeesApi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeesApi.Migrations
{
    [DbContext(typeof(EmployeesApiDbContext))]
    [Migration("20190126090623_uniqueFieldForEmployee")]
    partial class uniqueFieldForEmployee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeesApi.Entities.CountryCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CountryCodes");
                });

            modelBuilder.Entity("EmployeesApi.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("EmployeesApi.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("NationalityId");

                    b.Property<string>("PersonalNumber")
                        .IsRequired();

                    b.Property<int?>("SalaryId");

                    b.HasKey("Id");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PersonalNumber")
                        .IsUnique();

                    b.HasIndex("SalaryId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeesApi.Entities.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("EmployeesApi.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryCodeId");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("CountryCodeId", "Number")
                        .IsUnique();

                    b.ToTable("PhoneNumbers1");
                });

            modelBuilder.Entity("EmployeesApi.Entities.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Amount");

                    b.Property<int?>("CurrencyId");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("EmployeesApi.Entities.Employee", b =>
                {
                    b.HasOne("EmployeesApi.Entities.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeesApi.Entities.Salary", "Salary")
                        .WithMany()
                        .HasForeignKey("SalaryId");
                });

            modelBuilder.Entity("EmployeesApi.Entities.PhoneNumber", b =>
                {
                    b.HasOne("EmployeesApi.Entities.CountryCode", "CountryCode")
                        .WithMany()
                        .HasForeignKey("CountryCodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmployeesApi.Entities.Employee", "Employee")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmployeesApi.Entities.Salary", b =>
                {
                    b.HasOne("EmployeesApi.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });
#pragma warning restore 612, 618
        }
    }
}
