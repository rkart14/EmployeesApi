using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApi.Employees;
using EmployeesApi.Employees.Dto;
using EmployeesApi.Employees.Dto.Inputs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace EmployeesApi.Web.Controllers
{
    public class FileController : EmployeesApiControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmployeeAppService _employeeAppService;
        public FileController(IHostingEnvironment hostingEnvironment, IEmployeeAppService employeeAppService)
        {
            _hostingEnvironment = hostingEnvironment;
            _employeeAppService = employeeAppService;
        }
        public IActionResult AddEmployeesFromExcel()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    }
                    var employeeInputs = new List<CreateExcelEmployeeInput>();
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                        var firstName = row.GetCell(0).ToString(); // FirstName
                        var lastName = row.GetCell(1).ToString(); // Lastname
                        var personalNumber = row.GetCell(2).ToString(); // PN
                        var birthDate = row.GetCell(3).ToString(); // BD
                        var nationalityName = row.GetCell(4).ToString();

                        var salaryAmount = row.GetCell(4)?.NumericCellValue;
                        var SalaryCurrencyCode = row.GetCell(5)?.ToString();
                        var phoneNumbersString = row.GetCell(6)?.ToString();

                        employeeInputs.Add(new CreateExcelEmployeeInput
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            BirthDate = birthDate,
                            PersonalNumber = personalNumber,
                            NationalityName = nationalityName,
                            SalaryAmount = salaryAmount,
                            SalaryCurrencyCode = SalaryCurrencyCode,
                            PhoneNumbersString = phoneNumbersString
                        });
                    }
                    _employeeAppService.CreateList(employeeInputs);
                }
            }
            return Ok();
        }
    }
}