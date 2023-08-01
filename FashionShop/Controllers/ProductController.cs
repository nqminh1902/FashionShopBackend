using FashionShopBL.BaseBL;
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
        private readonly IWebHostEnvironment _environment;

        public ProductController(IBaseBL<Product> baseBL) : base(baseBL)
        {
        }

    }
}
