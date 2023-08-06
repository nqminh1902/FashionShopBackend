using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ProductImageDL
{
    public interface IProductImageDL:IBaseDL<ProductImage>
    {
        public ServiceResponse InsertProductImage(List<ProductImage> productImages);
    }
}
