using FashionShopBL.CandidateBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Entities.DTO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ImportBL
{
    public class ImportBL : IImportBL
    {
        private ICandidateBL _candidateBL;
        public ImportBL(ICandidateBL candidateBL)
        {
            _candidateBL = candidateBL;
        }
        public ServiceResponse ValidateImportCandidate(IFormFile formFile) 
        {
            var listCandidate = new List<Candidate>();  
            var listRowsError = new List<ImportError>();
            using(var stream = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                formFile.CopyTo(stream);
                using(var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];

                    var rowsCount = excelWorksheet.Dimension.Rows;
                    for(int row = 2; row <= rowsCount; row++)
                    {
                        bool isError = false;
                        List<string> Reason = new List<string>();
                        if(string.IsNullOrEmpty(excelWorksheet.Cells[row, 1].Value?.ToString()))
                        {
                            isError = true;
                            Reason.Add("Tên ứng viên không được để trống");
                        }
                        if (string.IsNullOrEmpty(excelWorksheet.Cells[row, 2].Value?.ToString()))
                        {
                            isError = true;
                            Reason.Add("Giới tính không được để trống");
                        }
                        if (string.IsNullOrEmpty(excelWorksheet.Cells[row, 3].Value?.ToString()))
                        {
                            isError = true;
                            Reason.Add("Số điện thoại ứng viên không được để trống");
                        }
                        if (string.IsNullOrEmpty(excelWorksheet.Cells[row, 4].Value?.ToString()))
                        {
                            isError = true;
                            Reason.Add("Ngày sinh ứng viên không được để trống");
                        }
                        if (string.IsNullOrEmpty(excelWorksheet.Cells[row, 5].Value?.ToString()))
                        {
                            isError = true;
                            Reason.Add("Email ứng viên không được để trống");
                        }
                        if (string.IsNullOrEmpty(excelWorksheet.Cells[row, 6].Value?.ToString()))
                        {
                            isError = true;
                            Reason.Add("Đại chỉ nhà ứng viên không được để trống");
                        }
                        if (isError)
                        {
                            listRowsError.Add(new ImportError
                            {
                                Row = row,
                                ErrorReason = string.Join(",", Reason),
                            });
                        }
                        else
                        {
                            listCandidate.Add(new Candidate
                            {
                                CandidateName = excelWorksheet.Cells[row, 1].Value.ToString()?.Trim(),
                                Gender = excelWorksheet.Cells[row, 2].Value.ToString()?.Trim() == "Nam" ? Gender.Male : Gender.Female,
                                Mobile = excelWorksheet.Cells[row, 3].Value.ToString()?.Trim(),
                                Birthday = ConvertStringToDateTime(excelWorksheet.Cells[row, 4].Value.ToString()),
                                Email = excelWorksheet.Cells[row, 5].Value.ToString()?.Trim(),
                                Address = excelWorksheet.Cells[row, 6].Value.ToString()?.Trim()
                            }); ;

                        }
                    }
                }
            }
            return new ServiceResponse()
            {
                Success = true,
                Data = new
                {
                    listCandidate,
                    listRowsError
                },
            };
                
        }


        private DateTime ConvertStringToDateTime(string dateString)
        {
            DateTime date;

            // Using TryParseExact
            bool isValidDate = DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            if (isValidDate)
            {
                return date;
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
