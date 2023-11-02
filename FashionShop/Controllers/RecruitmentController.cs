using FashionShopBL.RecruitmentBL;
using FashionShopBL.RecruitmentRoundBL;
using FashionShopCommon;
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
    }
}
