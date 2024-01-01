using FashionShopBL.EducationMajorBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationMajorController : BaseController<EducationMajor>
    {
        private readonly IEducationMajorBL _educationMajorBL;
        public EducationMajorController(IEducationMajorBL educationMajorBL):base(educationMajorBL)
        {
            _educationMajorBL = educationMajorBL;
        }
    }
}
