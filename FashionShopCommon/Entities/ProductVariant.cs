using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ProductVariant: BaseEnities
    {
        public int? ProductVariantID { get; set; }
        public int? ProductSizeID { get; set; }
        public int? ProductColorID { get; set; }
        public int Quantity { get; set; }
    }
}
