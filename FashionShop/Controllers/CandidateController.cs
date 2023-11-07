using FashionShopBL.CandidateBL;
using FashionShopCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : BaseController<Candidate>
    {
        private ICandidateBL _candidateBL;
        public CandidateController(ICandidateBL candidateBL) : base(candidateBL)
        {
            _candidateBL = candidateBL;
        }
    }
}
