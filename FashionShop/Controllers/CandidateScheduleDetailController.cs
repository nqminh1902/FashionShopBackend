using FashionShopBL.CandidateScheduleDetailBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateScheduleDetailController : BaseController<CandidateScheduleDetail>
    {
        private ICandidateScheduleDetailBL _candidateScheduleDetailBL;
        public CandidateScheduleDetailController(ICandidateScheduleDetailBL candidateScheduleDetailBL): base(candidateScheduleDetailBL)
        {
            _candidateScheduleDetailBL = candidateScheduleDetailBL;
        }


        /// <summary>
        /// danh sách lịch theo ID tin
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("get-by-recruitment")]
        public IActionResult getTotalCandidateByRound(PagingRequest pagingRequest)
        {
            try
            {
                var result = _candidateScheduleDetailBL.GetSheduleDetailByRecruitment(pagingRequest);

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
