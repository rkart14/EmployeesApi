using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using EmployeesApi.Common.Dto;
using EmployeesApi.Entities;

namespace EmployeesApi.Common
{
    public class LookupAppService : EmployeesApiAppServiceBase, ILookupAppService
    {
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IRepository<Nationality> _nationalityRepository;
        private readonly IRepository<CountryCode> _countryCodeRepository;
        private readonly IObjectMapper _objectMapper;
        public LookupAppService(
            IRepository<Currency> currencyRepository,
            IRepository<Nationality> nationalityRepository,
            IRepository<CountryCode> countryCodeRepository,
            IObjectMapper objectMapper
            )
        {
            _currencyRepository = currencyRepository;
            _nationalityRepository = nationalityRepository;
            _countryCodeRepository = countryCodeRepository;
            _objectMapper = objectMapper;
        }
        public async Task<List<CountryCodeDto>> GetCountryCodes()
        {
            var countryCodes = await _countryCodeRepository.GetAllListAsync();
            return _objectMapper.Map<List<CountryCodeDto>>(countryCodes);
        }

        public async Task<List<CurrencyDto>> GetCurrencies()
        {
            var currencies = await _currencyRepository.GetAllListAsync();
            return _objectMapper.Map<List<CurrencyDto>>(currencies);
        }

        public async Task<List<NationalityDto>> GetNationalities()
        {
            var nationalities = await _nationalityRepository.GetAllListAsync();
            return _objectMapper.Map<List<NationalityDto>>(nationalities);
        }
    }
}
