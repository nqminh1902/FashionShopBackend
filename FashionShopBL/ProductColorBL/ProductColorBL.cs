using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductColorDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ProductColorBL
{
    public class ProductColorBL : BaseBL<ProductColor>, IProductColorBL
    {
        private IProductColorDL _productColorDL;
        public ProductColorBL(IProductColorDL productColorDL) : base(productColorDL)
        {
            _productColorDL = productColorDL;
        }
    }
}
