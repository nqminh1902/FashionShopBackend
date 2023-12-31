﻿using FashionShopBL.RecruitmentBL;
using FashionShopBL.RecruitmentRoundBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.RecruitmentDL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : BaseController<Recruitment>
    {
        private IRecruitmentBL _recruitmentBL;
        public RecruitmentController(IRecruitmentBL recruitmentBL) : base(recruitmentBL)
        {
            _recruitmentBL = recruitmentBL;
        }

        /// <summary>
        /// Lây ds lý do người tuyển dụng
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [Authorize]
        [HttpGet("recruitment-broad/{recruitmentID}")]
        public async Task<IActionResult> getRecruitmentBroad(int recruitmentID)
        {
            try
            {
                var result = await _recruitmentBL.getRecruitmentBroad(recruitmentID);

                if (result.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 2,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
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
        [HttpPost("update-status/{recruitmentID}")]
        public async Task<IActionResult> updateRecruitmentStatus(int recruitmentID, [FromBody] int status)
        {
            try
            {
                var result = await _recruitmentBL.updateRecruitmentStatus(recruitmentID, status);

                if (result.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 2,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
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
