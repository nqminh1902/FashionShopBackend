﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ProductSize:BaseEnities
    {
        public int? ProductSizeID { get; set; }
        public string ProductSizeName { get; set; }
        public int ProductID { get; set; }
    }
}
