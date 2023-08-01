﻿using FashionShopBL.BaseBL;
using FashionShopCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {

                var records = _baseBL.GetAllRecords();

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                return StatusCode(StatusCodes.Status200OK, new List<T>());

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
        [HttpGet("{recordID}")]
        public IActionResult GetRecordByID([FromRoute] Guid recordID)
        {
            try
            {
                var record = _baseBL.GetRecordByID(recordID);

                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }
                // Thất bại
                return StatusCode(StatusCodes.Status404NotFound);
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
        [HttpDelete("{recordID}")]
        public IActionResult DeleteRecord([FromRoute] Guid recordID)
        {
            try
            {
                var ID = _baseBL.DeleteRecord(recordID);

                //Xử lý kết quả trả về

                //Thành công: Trả về Id nhân viên thêm thành công
                if (ID == recordID)
                {
                    return StatusCode(StatusCodes.Status200OK, ID);
                }
                //Thất bại
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resources.DevMsg_DeleteFail,
                    UserMsg = Resources.UserMsg_DeleteFail,
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
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T record)
        {
            try
            {
                var isValid = _baseBL.InsertRecord(record);
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
        /// Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <param name="record">Chi tiết bản ghi</param>
        /// <returns>ID của bản ghi vừa cập nhập</returns>
        /// CreateBy: Nguyễn Quang Minh (25/11/2022)
        [HttpPut("{recordID}")]
        public IActionResult UpdateRecord([FromRoute] Guid recordID, [FromBody] T record)
        {
            try
            {
                var isValid = _baseBL.UpdateRecord(recordID, record);


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
    }
}