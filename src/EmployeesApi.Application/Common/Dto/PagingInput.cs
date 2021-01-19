using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeesApi.Common.Dto
{
    public class PagingInput
    {
        public int PageNumber { get; set; }

        public int ItemsToFetch { get; set; }
    }
}
