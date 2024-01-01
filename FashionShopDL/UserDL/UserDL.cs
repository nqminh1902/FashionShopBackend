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
            string storeProcedureName = String.Format(Procedure.GET_User_Login);

            var parameters = new DynamicParameters();
            parameters.Add($"v_Username", user.UserName);
            parameters.Add($"v_Password", user.Password);


            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var record = mySqlConnection.QueryFirstOrDefault<User>(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                return record;
            }
        }
    }
}
