using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities.DTO
{
    public class PagingResult
    {
        /// <summary>
        /// Danh sách bản ghi
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        ///  tổng số bản ghi
        /// </summary>
        public long TotalCount { get; set; }
    }
}
