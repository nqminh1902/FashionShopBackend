using FashionShopBL.RecruitmentDetailBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentDetailController : BaseController<RecruitmentDetail>
    {
        private IRecruitmentDetailBL _recruitmentDetail;
        public RecruitmentDetailController(IRecruitmentDetailBL recruitmentDetailBL): base(recruitmentDetailBL)
        {
            _recruitmentDetail = recruitmentDetailBL;
        }

        /// <summary>
        /// Xóa danh sách theo ID
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpGet("getTotalByRound")]
        public IActionResult getTotalCandidateByRound(int recruitmentID, int status, int period)
        {
            try
            {
                var result = _recruitmentDetail.getTotalCandidateByRound(recruitmentID, status, period);

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

        /// <summary>
        /// Chuyển vòng tuyển dụng
        /// </summary>
        [HttpPost("changeRound")]
        public IActionResult ChangeRound([FromBody] ChangeRoundDTO keyValuePairs)
        {
            try
            {
                var result = _recruitmentDetail.ChangeRound(keyValuePairs);

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

        /// <summary>
        /// Lây ds lý do loại Ứng viên
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpGet("get-eliminate")]
        public IActionResult GetEliminate()
        {
            try
            {
                var result = _recruitmentDetail.GetEliminate();

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

        /// <summary>
        /// Lây ds lý do loại Ứng viên
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("eliminate/{recordID}/{recruitmentID}/{isSendMail}")]
        public IActionResult EliminateCandiadte(int recordID, [FromBody] List<int> ids, int recruitmentID, bool isSendMail)
        {
            try
            {
                var result = _recruitmentDetail.EliminateCandiadte(recordID, ids, recruitmentID, isSendMail);

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

        /// <summary>
        /// Chuyển thành nhân viên
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("employee/{recordID}/{recruitmentID}")]
        public IActionResult TransferToEmployee(int recordID, [FromBody] List<int> ids, int recruitmentID)
        {
            try
            {
                var result = _recruitmentDetail.TransferToEmployee(recordID, ids, recruitmentID);

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

        /// <summary>
        /// Lây tin ứng tuyển theo id ứng viên
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpGet("get-by-canidate-id/{id}")]
        public IActionResult getByCandidateID(int id)
        {
            try
            {
                var result = _recruitmentDetail.getByCandidateID(id);

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

        /// <summary>
        /// Thu hồi trạng thái nhân viên
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("revoke-employee/{recruitmentID}")]
        public IActionResult RevokeEmployee([FromBody]List<int> ids, int recruitmentID)
        {
            try
            {
                var result = _recruitmentDetail.RevokeEmployee(ids, recruitmentID);

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

        /// <summary>
        /// Tiếp tục tuyển dụng
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("continue-recruit/{recruitmentID}")]
        public IActionResult ContinueRecruit([FromBody] List<int> ids, int recruitmentID)
        {
            try
            {
                var result = _recruitmentDetail.ContinueRecruit(ids, recruitmentID);

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

        /// <summary>
        /// Tiếp tục tuyển dụng
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("remove-from-recruit/{recruitmentID}")]
        public IActionResult RemoveFromRecruitment([FromBody] List<int> ids, int recruitmentID)
        {
            try
            {
                var result = _recruitmentDetail.RemoveFromRecruitment(ids, recruitmentID);

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

        /// <summary>
        /// Tiếp tục tuyển dụng
        /// </summary>
        /// <param name="">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("change-recruitment/{recruitmentID}/{choose}/{recruitmentRound}/{period}")]
        public IActionResult ChangeRecruitment([FromBody] List<int> ids, int recruitmentID, int recruitmentRound, int choose,int period)
        {
            try
            {
                var result = _recruitmentDetail.ChangeRecruitment(ids, recruitmentID, recruitmentRound, choose, period);

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
