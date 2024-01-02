using FashionShopBL.BaseBL;
using FashionShopBL.RoleBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.RoleDL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController:BaseController<Role>
    {
        private IRoleBL _roleBL;
        public RoleController(IRoleBL roleBL):base(roleBL)
        {
            _roleBL = roleBL;
        }

        [Authorize]
        [HttpPost("save")]
        public async Task<IActionResult> SaveRole([FromBody]Role role)
        {
            try
            {
                var response = await _roleBL.SaveRole(role);

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
