using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.UserDL
{
    public class UserDL: BaseDL<User>, IUserDL
    {
        public User Login(User user)
        {
            // Chuẩn bị câu lệnh SQL
            string sql = "SELECT * FROM user u WHERE u.UserName = '{0}' AND u.Password = '{1}';";

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var record = mySqlConnection.QueryFirstOrDefault<User>(string.Format(sql, user.UserName, user.Password));
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                return record;
            }
        }
    }
}
