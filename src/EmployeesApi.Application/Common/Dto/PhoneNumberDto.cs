using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Common.Dto
{
    public class PhoneNumberDto :EntityDto
    {

        public int CountryCodeId { get; set; }

        public string CountryCode { get; set; }

        public string Number { get; set; }
    }
}
