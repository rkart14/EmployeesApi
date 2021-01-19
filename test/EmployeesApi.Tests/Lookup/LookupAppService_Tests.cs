using EmployeesApi.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApi.Tests.Lookup
{
    public class LookupAppService_Tests: EmployeesApiTestBase
    {
        private readonly ILookupAppService _lookupAppService;
        public LookupAppService_Tests()
        {
            _lookupAppService = Resolve<ILookupAppService>();
        }

        [Fact]
        public async Task Should_Get_All_lookupData()
        {
            //Act
            var countryCodesOutput = await _lookupAppService.GetCountryCodes();

            var currenciesOutput = await _lookupAppService.GetCurrencies();

            var nationalitiesOutput = await _lookupAppService.GetNationalities();

            //Assert
            countryCodesOutput.Count().ShouldBe(1);
            currenciesOutput.Count().ShouldBe(2);
            nationalitiesOutput.Count().ShouldBe(3);
        }
    }
}
