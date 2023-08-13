using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class PagingRequest
    {
        // Số bản ghi trong 1 page
        public int PageSize { get; set; } = 25;

        // Số page 
        public int PageIndex { get; set; } = 1;

        // Chuỗi cần tìm kiếm
        public string? SearchValue { get; set; } = "";

        // Collum cần tìm kiếm theo search value
        public List<string>? Collums { get; set; }

        // Điều kiện sắp xếp bản ghi
        public List<string>? SortOrder { get; set; }

        // Giá trị custom muốn truyền theo để xử lý logic gì đó nếu cần
        public Dictionary<string, object>? CustomParam { get; set; }

        // Lọc giá dữ liệu theo điều kiện tùy chỉnh
        // Frontend: btoa([["CreateDate","<>","Minh"],["Price",">","20000"]]')
        public string? CustomFilter { get; set; }
    }
}
