using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.FluentValidation;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeesApi.Common.Dto;
using EmployeesApi.Employees.Dto;
using EmployeesApi.Entities;

namespace EmployeesApi
{
    [DependsOn(
        typeof(EmployeesApiCoreModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpFluentValidationModule))]
    public class EmployeesApiApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeesApiApplicationModule).GetAssembly());
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreatePhoneNumberInput, PhoneNumber>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

                config.CreateMap<CreateEmployeeInput, Employee>()
                    .ForMember(u => u.Salary, options => options.MapFrom(input =>
                      (input.SalaryCurrencyId.HasValue || input.SalaryAmount.HasValue) ?
                      new Salary
                      {
                          CurrencyId = input.SalaryCurrencyId ?? null,
                          Amount = input.SalaryAmount ?? null
                      } : null));

                config.CreateMap<PhoneNumber, PhoneNumberDto>()
                    .ForMember(dto => dto.CountryCode, options => options.MapFrom(input => input.CountryCode.Code));

                config.CreateMap<AddNumberInput, PhoneNumber>();

                config.CreateMap<EditNumberInput, PhoneNumber>()
                    .ForMember(p => p.Id, options => options.MapFrom(input => input.NumberId));

                config.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dto => dto.Nationality, option => option.MapFrom(input => input.Nationality.Name))
                    .ForMember(dto => dto.SalaryAmount, option => option.MapFrom(input => input.Salary == null ? 0 : input.Salary.Amount))
                    .ForMember(dto => dto.SalaryCurrencyCode, option => option.MapFrom(input => input.Salary == null ? string.Empty : input.Salary.Currency.Code));
            });
        }
    }
}