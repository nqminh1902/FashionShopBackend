using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ProductSizeDL
{
    public interface IProductSizeDL:IBaseDL<ProductSize>
    {
        public ServiceResponse GetSizesByID(int id);
    }
}
