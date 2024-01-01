using FashionShopBL.WorkLocationBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : BaseController<WorkLocation>
    {
        private IWorkLocationBL _workLocationBL;
        public WorkLocationController(IWorkLocationBL workLocationBL):base(workLocationBL)
        {
            _workLocationBL = workLocationBL;
        }
    }
}
