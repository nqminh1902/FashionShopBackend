using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ProductVariant: BaseEnities
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public int ProductSizeID { get; set; }
        public int ProductColorID { get; set; }
    }
}
