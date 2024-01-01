using FashionShopBL.ExportBL;
using FashionShopCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Collections.Generic;
using FashionShopBL.CandidateBL;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IExportBL _exportBL;
        private readonly ICandidateBL _candidateBL;
        public ExportController(IExportBL exportBL, ICandidateBL candidateBL)
        {
            _exportBL = exportBL;
            _candidateBL = candidateBL;
        }

        [HttpPost("export-candidate")]
        public IActionResult ExportCandidate([FromBody] List<int> ids)
        {
            try
            {
                var listCandidate = new List<Candidate>();
                if (ids.Count > 0)
                {
                    var res = _candidateBL.GetByIDs(ids).Result;

                    listCandidate.AddRange((List<Candidate>)res.Data);
                }
                else
                {
                    var res =  _candidateBL.GetAllRecords();
                    if (res.Success)
                    {
                        listCandidate.AddRange((List<Candidate>)res.Data);
                    }
                }

                // Lấy dữ liệu từ database
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                if (listCandidate != null)
                {
                    // Khởi tạo vùng nhớ
                    var stream = new MemoryStream();
                    using (var xlPackage = new ExcelPackage(stream))
                    {
                        // Tạo và đặt tên cho sheet
                        var worksheet = xlPackage.Workbook.Worksheets.Add("DSUV");
                        const int startRow = 4;
                        var row = startRow;
                        var stt = 1;

                        // Khởi tạo title
                        worksheet.Cells["A2"].Value = "Danh sách ứng viên";
                        using (var r = worksheet.Cells["A2:R2"])
                        {
                            // Merge hàngA4:R4
                            r.Merge = true;
                            // Cho chữ căn giữa
                            r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            // Set phông chữ
                            r.Style.Font.SetFromFont("Times New Roman", 16, true);


                        }

                        // Set chiều rộng cột excel
                        worksheet.Column(1).Width = 25;
                        worksheet.Column(2).Width = 25;
                        worksheet.Column(3).Width = 25;
                        worksheet.Column(4).Width = 25;
                        worksheet.Column(5).Width = 25;
                        worksheet.Column(6).Width = 25;
                        worksheet.Column(7).Width = 25;
                        worksheet.Column(8).Width = 25;
                        worksheet.Column(9).Width = 25;
                        worksheet.Column(10).Width = 25;
                        worksheet.Column(11).Width = 25;
                        worksheet.Column(12).Width = 25;
                        worksheet.Column(13).Width = 25;
                        worksheet.Column(14).Width = 25;

                        // Gán tên header cho từng cột khi xuất ra file excel
                        worksheet.Cells["A4"].Value = "Tên ứng viên";
                        worksheet.Cells["B4"].Value = "Ngày sinh";
                        worksheet.Cells["C4"].Value = "Địa chỉ";
                        worksheet.Cells["D4"].Value = "Email";
                        worksheet.Cells["E4"].Value = "Giới tính";
                        worksheet.Cells["F4"].Value = "Số điện thoại";
                        worksheet.Cells["G4"].Value = "Chuyên ngành";
                        worksheet.Cells["H4"].Value = "Nơi đào tạo";
                        worksheet.Cells["I4"].Value = "Trình độ";
                        worksheet.Cells["J4"].Value = "Nơi làm việc gần đây";
                        worksheet.Cells["K4"].Value = "Tin ứng tuyển";
                        worksheet.Cells["L4"].Value = "Vòng ứng tuyển";
                        worksheet.Cells["M4"].Value = "Vị trí ứng tuyển";
                        worksheet.Cells["N4"].Value = "Trạng thái tuyển dụng";


                        var modelRows = listCandidate.Count() + 4;
                        string modelRange = "A4:R" + modelRows.ToString();
                        using (var range = worksheet.Cells[modelRange])
                        {
                            // Set phông chữ
                            range.Style.Font.SetFromFont("Times New Roman", 12, false);

                            // Set Border
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        }

                        // Lấy range vào tạo format cho range đó ở đây là từ A3 tới I3
                        using (var range = worksheet.Cells["A4:R4"])
                        {
                            range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            // Set PatternType
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                            // Set Font cho text  trong Range hiện tại
                            range.Style.Font.SetFromFont("Times New Roman", 12, true);
                            // Set Border
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        }

                        // Truyền dữ liệu vào excel
                        row = 5;
                        foreach (var candidate in listCandidate)
                        {
                            worksheet.Cells[row, 1].Value = candidate.CandidateName;
                            worksheet.Cells[row, 2].Value = candidate.Birthday;
                            worksheet.Cells[row, 2].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                            worksheet.Cells[row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                            worksheet.Cells[row, 3].Value = candidate.Address;
                            worksheet.Cells[row, 4].Value = candidate.Email;
                            worksheet.Cells[row, 5].Value = candidate.Gender == Gender.Male ? "Nam" : "Nữ";
                            worksheet.Cells[row, 6].Value = candidate.Mobile;
                            worksheet.Cells[row, 7].Value = candidate.EducationMajorName;
                            worksheet.Cells[row, 8].Value = candidate.EducationPlaceName;
                            worksheet.Cells[row, 9].Value = candidate.EducationDegreeName;
                            worksheet.Cells[row, 10].Value = candidate.WorkPlaceRecent;
                            worksheet.Cells[row, 11].Value = candidate.RecruitmentName;
                            worksheet.Cells[row, 12].Value = candidate.RecruitmentRoundName;
                            worksheet.Cells[row, 13].Value = candidate.JobPositionName;
                            worksheet.Cells[row, 13].Value = candidate.CandidateStatusName;
                            row++;
                            stt++;
                        }
                        // Lưu spreadsheet mới
                        xlPackage.Save();
                    }

                    stream.Position = 0;
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DSUV.xlsx");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
    }
}
