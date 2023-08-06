using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductImageDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ProductImageBL
{
    public class ProductImageBL : BaseBL<ProductImage>, IProductImageBL
    {
        private IProductImageDL _productImageDL;
        public ProductImageBL(IProductImageDL productImageDL) : base(productImageDL)
        {
            _productImageDL = productImageDL;
        }
    }
}
