using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class PagingRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; } = 0;

        public string? SearchValue { get; set; }
        public object? CustomParam { get; set; }
    }
}
