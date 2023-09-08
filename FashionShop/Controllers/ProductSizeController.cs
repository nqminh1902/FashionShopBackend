using FashionShopBL.BaseBL;
using FashionShopBL.ProductColorBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : BaseController<ProductSize>
    {
        public ProductSizeController(IBaseBL<ProductSize> baseBL) : base(baseBL)
        {
        }
    }
}
