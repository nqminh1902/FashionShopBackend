using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductVariantDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ProductVariantBL
{
    public class ProductVariantBL : BaseBL<ProductVariant>, IProductVariantBL
    {
        private IProductVariantDL _productVariantDL;
        public ProductVariantBL(IProductVariantDL productVariantDL) : base(productVariantDL)
        {
            _productVariantDL = productVariantDL;
        }
    }
}
