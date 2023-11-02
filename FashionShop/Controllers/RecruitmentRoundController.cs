using FashionShopBL.RecruitmentPeriodBL;
using FashionShopBL.RecruitmentRoundBL;
using FashionShopCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentRoundController : BaseController<RecruitmentRound>
    {
        private IRecruitmentRoundBL _recruitmentRoundBL;
        public RecruitmentRoundController(IRecruitmentRoundBL recruitmentRoundBL) : base(recruitmentRoundBL)
        {
            _recruitmentRoundBL = recruitmentRoundBL;
        }
    }
}
