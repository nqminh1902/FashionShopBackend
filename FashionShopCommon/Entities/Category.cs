using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Category: BaseEnities
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
        //Trạng thái danh mục sản phẩm: Ngừng kích hoạt:0; Kích hoạt: 1
        public int CategoryStatus { get; set; }
    }
}
