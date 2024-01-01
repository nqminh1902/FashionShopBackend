using FashionShopBL.UniversityBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : BaseController<University>
    {
        private IUniversityBL _universityBL;
        public UniversityController(IUniversityBL universityBL):base(universityBL)
        {
            _universityBL = universityBL;
        }
    }
}
