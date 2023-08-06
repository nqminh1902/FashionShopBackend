using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using FashionShopDL.ProductDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ProductBL
{
    public class ProductBL : BaseBL<Product>, IProductBL
    {
        private IProductDL _productBL;
        public ProductBL(IProductDL productBL) : base(productBL)
        {
            _productBL = productBL;
        }
    }
}
