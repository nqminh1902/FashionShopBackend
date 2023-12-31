﻿using FashionShopBL.Report;
using FashionShopCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportBL _reportBL;
        public ReportController(IReportBL reportBL)
        {
            _reportBL = reportBL;
        }

        [Authorize]
        [HttpPost("getDataReportByRecruitment/{recruitmentID}/{periodID}")]
        public async Task<IActionResult> GetDataReportByRecruitment(int recruitmentID, int periodID)
        {
            try
            {
                var response = await _reportBL.GetDataReportByRecruitment(recruitmentID, periodID);
                // Thành công: Trả về dữ liệu cho FE
                if (response.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                // Thất bại
                return StatusCode(StatusCodes.Status404NotFound, response);
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

        [Authorize]
        [HttpPost("getCandidateByTime/{recruitmentID}")]
        public async Task<IActionResult> GetCandidateByTime([FromBody] Dictionary<string,object> request, int recruitmentID)
        {
            try
            {
                var response = await _reportBL.GetCandidateByTime(request, recruitmentID);

                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (response.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                // Thất bại
                return StatusCode(StatusCodes.Status404NotFound, response);
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
