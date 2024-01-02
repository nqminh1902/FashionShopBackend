using FashionShopBL.PermissionBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController:BaseController<Permission>
    {
        private IPermissionBL _permissionBL;
        public PermissionController(IPermissionBL permissionBL):base(permissionBL) 
        {
            _permissionBL = permissionBL;  
        }

        [Authorize]
        [HttpGet("getByRoleID/{roleID}")]
        public async Task<IActionResult> GetByRoleID(int roleID)
        {
            try
            {
                var response = await _permissionBL.GetByRoleID(roleID); 

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
