using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ProductImage
    {
        public int? ProductImageID { get; set; }
        public string ImageUrl { get; set;}
        public string ImageID { get; set; }
        public int ProductID { get; set; }
    }
}
