using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Product: BaseEnities
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? Description { get; set; }
        public string? Material { get; set; }
        public int TotalQuantity { get; set; }
        public string? QuickDescription { get; set; }
        public int CollectionID { get; set; }
        public int CategoryID { get; set; }
        [DetailTable]
        public List<ProductColor>? ProductColors { get; set; }
        [DetailTable]
        public List<ProductSize>? ProductSizes { get; set; }
        [DetailTable]
        public List<ProductImage>? ProductImages { get; set; }
        public ProductStatus Status { get; set; }

    }
}
