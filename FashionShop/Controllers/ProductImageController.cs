using FashionShopBL.BaseBL;
using FashionShopBL.ProductImageBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController<ProductImage>
    {
        private IProductImageBL _productImageBL;
        public ProductImageController(IProductImageBL productImageBL) : base(productImageBL)
        {
            _productImageBL = productImageBL;
        }
    }
}
