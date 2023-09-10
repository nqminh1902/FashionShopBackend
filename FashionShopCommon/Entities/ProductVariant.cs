using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ProductVariant: BaseEnities
    {
        public int ProductVariantID { get; set; }
        public int? ProductID { get; set; }
        public int? ProductSizeID { get; set; }
        public string? ProductSizeName { get; set; }
        public int? ProductColorID { get; set; }
        public string? ProductColorName { get; set; }
        public int Quantity { get; set; }
    }
}
