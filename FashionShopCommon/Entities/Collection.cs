using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Collection: BaseEnities
    {
        public int? CollectionID { get; set; }
        public string CollectionName { get; set; }
        public int Status { get; set; }
    }
}
