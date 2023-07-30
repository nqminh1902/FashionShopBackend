using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    /// <summary>
    /// Enum sử dụng mô tả các lỗi sảy ra khi gọi API
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Lỗi gặp Exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi trùng mã
        /// </summary>
        DuplicateCode = 2,

        /// <summary>
        /// Lỗi dữ liệu đầu vào không hợp lệ
        /// </summary>
        InValidData = 3,
    }
}

