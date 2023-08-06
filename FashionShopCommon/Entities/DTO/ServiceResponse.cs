using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class ServiceResponse
    {
        /// <summary>
        /// Có lỗi hay không nếu có trả về false, không thì trả về true
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Danh sách lỗi
        /// </summary>
        public object Data { get; set; }
    }
}
