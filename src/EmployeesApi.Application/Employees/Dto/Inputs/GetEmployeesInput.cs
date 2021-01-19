using Abp.Runtime.Validation;
using EmployeesApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Employees.Dto
{
    public class GetEmployeesInput : PagingInput, IShouldNormalize
    {
        public const int _defaultItemsToFetch = 10;
        public const int _defaultPageNumber = 1;

        public void Normalize()
        {
            if (PageNumber == 0)
                PageNumber = _defaultPageNumber;
            if (ItemsToFetch == 0)
                ItemsToFetch = _defaultItemsToFetch;
        }
    }
}
