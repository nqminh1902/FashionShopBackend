using FashionShopBL.EmailBL;
using FashionShopCommon;
using FashionShopCommon.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailBL _emailBL;
        public EmailController(IEmailBL emailBL)
        {
            _emailBL = emailBL;
        }
    }
}
