using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Common.Dto
{
    public class CurrencyDto : EntityDto
    {
        public string Code { get; set; }
    }
}
