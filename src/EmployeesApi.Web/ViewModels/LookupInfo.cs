using EmployeesApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Web.ViewModels
{
    public class LookupInfo
    {
        public List<CountryCodeDto> CountryCodes { get; set; }
        public List<NationalityDto> Nationalities { get; set; }

        public List<CurrencyDto> Currencies { get; set; }
    }
}
