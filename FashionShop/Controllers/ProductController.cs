using FashionShopBL.BaseBL;
using FashionShopBL.ProductBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        private IProductBL _productBL;
        public ProductController(IProductBL productBL) : base(productBL)
        {
            _productBL = productBL;
        }
    }
}
