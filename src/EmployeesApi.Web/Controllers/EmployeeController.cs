using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Web.Models;
using EmployeesApi.Common;
using EmployeesApi.Employees;
using EmployeesApi.Employees.Dto;
using EmployeesApi.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApi.Web.Controllers
{
    public class EmployeeController : EmployeesApiControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly ILookupAppService _lookupAppService;

        public EmployeeController(IEmployeeAppService employeeAppService, ILookupAppService lookupAppService)
        {
            _employeeAppService = employeeAppService;
            _lookupAppService = lookupAppService;
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeInput input)
        {
            await _employeeAppService.Create(input);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var lookupTasks = new List<Task>
            {
                _lookupAppService.GetNationalities(),
                _lookupAppService.GetCurrencies(),
                _lookupAppService.GetCountryCodes()
            };
            var nationalities = await _lookupAppService.GetNationalities();
            var currencies = await _lookupAppService.GetCurrencies();
            var countryCodes = await _lookupAppService.GetCountryCodes();

            return View(new LookupInfo
            {
                Nationalities = nationalities,
                CountryCodes = countryCodes,
                Currencies = currencies
            });
        }

        public async Task<IActionResult> Edit(GetEmployeeInput input)
        {
            var result = await _employeeAppService.GetAsync(input);
            var nationalities = await _lookupAppService.GetNationalities();
            var currencies = await _lookupAppService.GetCurrencies();
            var countryCodes = await _lookupAppService.GetCountryCodes();
            return View(new EditEmployeeViewModel
            {
                LookUpInfo = new LookupInfo
                {
                    Nationalities = nationalities,
                    CountryCodes = countryCodes,
                    Currencies = currencies
                },
                Employee = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditNumber(EditNumberInput input)
        {
            await _employeeAppService.EditNumber(input);
            return Ok();
        }

        [WrapResult]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeInput input)
        {
            await _employeeAppService.Update(input);
            return Ok();
        }
    }
}