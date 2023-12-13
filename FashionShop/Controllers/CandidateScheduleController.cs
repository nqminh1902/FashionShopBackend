using FashionShopBL.CandidateScheduleBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateScheduleController : BaseController<CandidateSchedule>
    {
        private ICandidateScheduleBL _candidateScheduleBL;
        public CandidateScheduleController(ICandidateScheduleBL candidateScheduleBL):base(candidateScheduleBL)
        {
            _candidateScheduleBL = candidateScheduleBL;
        }
    }
}
