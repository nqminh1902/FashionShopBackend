using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : BaseController<Collection>
    {
        public CollectionController(IBaseBL<Collection> baseBL) :base(baseBL) 
        { 
        }
    }
}
