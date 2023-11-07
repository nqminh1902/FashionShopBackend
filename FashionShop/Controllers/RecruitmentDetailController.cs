using FashionShopBL.RecruitmentDetailBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentDetailController : BaseController<RecruitmentDetail>
    {
        private IRecruitmentDetailBL _recruitmentDetail;
        public RecruitmentDetailController(IRecruitmentDetailBL recruitmentDetailBL): base(recruitmentDetailBL)
        {
            _recruitmentDetail = recruitmentDetailBL;
        }
    }
}
