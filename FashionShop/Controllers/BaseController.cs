using FashionShopBL.BaseBL;
using FashionShopCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field
        private IBaseBL<T> _baseBL;
        #endregion

        #region Constructor
        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion

        #region Method
        /// <summary>
        /// API lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Trả về danh sách bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (03/11/2022)
        [Authorize]
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {

                var records = _baseBL.GetAllRecords();

                return StatusCode(StatusCodes.Status200OK, records);

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
        /// API lấy thông tin 1 bản ghi theo ID
        /// </summary>
        /// <returns>Trả về thông tin 1 bản ghi theo ID</returns>
        /// CreatedBy: Nguyễn Quang Minh (03/11/2022)
        [Authorize]
        [HttpGet("{recordID}")]
        public async Task<IActionResult> GetRecordByID([FromRoute] int recordID)
        {
            try
            {
                var response = await _baseBL.GetRecordByID(recordID);

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


        /// <summary>
        /// API xóa một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// CreatedBy: Nguyễn Quang Minh (03/3/2022)
        [Authorize]
        [HttpDelete("{recordID}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int recordID)
        {
            try
            {
                var serviceResponse = await _baseBL.DeleteRecord(recordID);

                //Xử lý kết quả trả về

                //Thành công: Trả về Id nhân viên thêm thành công
                if (serviceResponse.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, serviceResponse);
                }
                //Thất bại
                return StatusCode(StatusCodes.Status500InternalServerError, serviceResponse);
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
        /// Xóa danh sách theo ID
        /// </summary>
        /// <param name="">danh sách ID đơn</param>ca
        /// <returns>Danh sách đơn đã xóa</returns>
        [Authorize]
        [HttpPost("deleteBulk")]
        public async Task<IActionResult> DeleteMultipleEmployee([FromBody] List<int> ids)
        {
            try
            {
                var result = await _baseBL.DeleteMultiple(ids);

                if (result.Success)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 2,
                    DevMsg = Resources.DevMsg_DeleteMultipleFail,
                    UserMsg = Resources.UserMsg_DeleteMultipleFail,
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
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Chi tiết bản ghi</param>
        /// <returns>ID bản ghi thêm thành công</returns>
        /// CreateBy: Nguyễn Quang Minh(25/11/2022)
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertRecord([FromBody] T record)
        {
            try
            {
                var isValid = await _baseBL.InsertRecord(record);
                //Xử lý kết quả trả về
                if (!isValid.Success)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        ErrorCode = ErrorCode.InValidData,
                        DevMsg = Resources.DevMsg_Required,
                        UserMsg = isValid.Data,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceId = HttpContext.TraceIdentifier
                    });

                }
                return StatusCode(StatusCodes.Status201Created, isValid);
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
        /// Thêm mới nhiều bản ghi bản ghi
        /// </summary>
        /// <param name="record">Chi tiết bản ghi</param>
        /// <returns>ID bản ghi thêm thành công</returns>
        /// CreateBy: Nguyễn Quang Minh(25/11/2022)
        [Authorize]
        [HttpPost("insertBulk")]
        public async Task<IActionResult> InsertMultipleRecord([FromBody] List<T> records)
        {
            try
            {
                var isValid = await _baseBL.InsertMultipleRecord(records);
                //Xử lý kết quả trả về
                if (!isValid.Success)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        ErrorCode = ErrorCode.InValidData,
                        DevMsg = Resources.DevMsg_Required,
                        UserMsg = isValid.Data,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceId = HttpContext.TraceIdentifier
                    });

                }
                return StatusCode(StatusCodes.Status200OK, isValid);
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
        /// Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <param name="record">Chi tiết bản ghi</param>
        /// <returns>ID của bản ghi vừa cập nhập</returns>
        /// CreateBy: Nguyễn Quang Minh (25/11/2022)
        [Authorize]
        [HttpPut("{recordID}")]
        public async Task<IActionResult> UpdateRecord([FromRoute] int recordID, [FromBody] T record)
        {
            try
            {
                var isValid = await _baseBL.UpdateRecord(recordID, record);


                //Xử lý kết quả trả về
                if (!isValid.Success)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        ErrorCode = ErrorCode.InValidData,
                        DevMsg = Resources.DevMsg_Required,
                        UserMsg = isValid.Data,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceId = HttpContext.TraceIdentifier
                    });

                }
                return StatusCode(StatusCodes.Status201Created, isValid);
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
        #endregion

        /// <summary>
        /// Hàm xử lý lấy dữ liệu theo phân trang
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("paging")]
        public async Task<IActionResult> GetPaging([FromBody] PagingRequest pagingRequest)
        {
            try
            {

                var result = await _baseBL.GetPaging(pagingRequest);

                return StatusCode(StatusCodes.Status200OK, result);
           
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
