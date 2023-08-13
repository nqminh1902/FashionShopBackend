using FashionShopBL.BaseBL;
using FashionShopBL.ProductColorBL;
using FashionShopCommon.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorController : BaseController<ProductColor>
    {
        private IProductColorBL _productColor;
        public ProductColorController(IProductColorBL productColorBL) : base(productColorBL)
        {
            _productColor = productColorBL;
        }
    }
}