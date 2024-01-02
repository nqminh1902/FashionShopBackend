using FashionShopAPI.Middleware;
using FashionShopBL.UserBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        private IUserBL _userBL;

        private IConfiguration _configuration;
        public UserController(IUserBL userBL, IConfiguration configuration) : base(userBL)
        {
            _userBL = userBL;
            _configuration = configuration;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                var result = _userBL.Login(user);

                if (result != null)
                {
                    JwtToken jwt = new JwtToken(_configuration);
                    var token = jwt.Generate(result);
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        User = result,
                        Token = token,
                    });
                }
                // Thất bại
                return StatusCode(StatusCodes.Status401Unauthorized);
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
