using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Category: BaseEnities
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
    }
}
