using Abp.Application.Services;
using EmployeesApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApi.Common
{
    public interface ILookupAppService : IApplicationService
    {
        Task<List<CountryCodeDto>> GetCountryCodes();
        Task<List<CurrencyDto>> GetCurrencies();
        Task<List<NationalityDto>> GetNationalities();
    }
}
