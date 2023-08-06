using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductSizeDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ProductSizeBL
{
    public class ProductSizeBL : BaseBL<ProductSize>, IProductSizeBL
    {
        private IProductSizeDL _productSizeDL;
        public ProductSizeBL(IProductSizeDL productSizeDL) : base(productSizeDL)
        {
            _productSizeDL = productSizeDL;
        }
    }
}
