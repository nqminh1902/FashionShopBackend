using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ProductColor: BaseEnities
    {
        public int? ProductColorID { get; set; }
        public string ProductColorName { get; set; }

        public string ProductColorImage { get; set; }
        public int ProductID { get; set;}
    }
}
