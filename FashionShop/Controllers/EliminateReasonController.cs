using FashionShopBL.EliminateReasonBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EliminateReasonController : BaseController<EliminateReason>
    {
        private readonly IEliminateReasonBL _eliminateReasonBL;
        public EliminateReasonController(IEliminateReasonBL eliminateReasonBL):base(eliminateReasonBL)
        {
            _eliminateReasonBL = eliminateReasonBL;
        }
    }
}
