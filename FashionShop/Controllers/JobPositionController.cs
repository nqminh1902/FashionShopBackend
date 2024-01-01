using FashionShopBL.JobPositionBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionController : BaseController<JobPosition>
    {
        private IJobPositionBL _jobPositionBL;
        public JobPositionController(IJobPositionBL jobPositionBL):base(jobPositionBL)
        {
            _jobPositionBL = jobPositionBL;
        }
    }
}
