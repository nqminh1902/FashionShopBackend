using FashionShopBL.RecruitmentPeriodBL;
using FashionShopCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentPeriodController : BaseController<RecruitmentPeriod>
    {
        private IRecruitmentPeriodBL _recruitmentPeriodBL;
        public RecruitmentPeriodController(IRecruitmentPeriodBL recruitmentPeriodBL) :base(recruitmentPeriodBL) 
        {
            _recruitmentPeriodBL = recruitmentPeriodBL;
        }
    }
}
