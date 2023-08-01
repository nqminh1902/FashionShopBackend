using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Collection: BaseEnities
    {
        public int CollectionID { get; set; }
        public string CollectionName { get; set; }
        public int ProductID { get; set; }
        // Trạng thái Bộ sưu tập. Ngừng kích hoạt: 0; Kích hoạt: 1
        public int CollectionStatus { get; set; }
    }
}
