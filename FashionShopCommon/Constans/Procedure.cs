using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class Procedure
    {
        /// <summary>
        /// Format tên của procedure lấy tất cả bản ghi
        /// </summary>
        public static string GET_ALL = "Proc_{0}_GetAll";

        /// <summary>
        /// Format tên của procedure lấy bản ghi theo ID
        /// </summary>
        public static string GET_BY_ID = "Proc_{0}_GetByID";

        /// <summary>
        /// Format tên của procedure xóa 1 bản ghi theo ID
        /// </summary>
        public static string DELETE = "Proc_{0}_Delete";

        /// <summary>
        /// Tên của procedure sửa bản ghi
        /// </summary>
        public static string UPDATE_RECORD = "Proc_{0}_Update";

        /// <summary>
        /// Tên của procedure thêm bản ghi
        /// </summary>
        public static string INSERT_RECORD = "Proc_{0}_Insert";

        /// <summary>
        /// Tên của procedure phân trang và tìm kiếm
        /// </summary>
        public static string GET_BY_FILTER_PAGING = "Proc_{0}_GetPaging";

        /// <summary>
        /// Tên của procedure tìm mã nhân viên
        /// </summary>
        public static string GET_CODE_BY_CODE = "Proc_{0}_GetSameID";


        public static string GET_User_Login = "Proc_User_Login";
    }
}
