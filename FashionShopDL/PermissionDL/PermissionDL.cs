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

namespace FashionShopDL.PermissionDL
{
    public class PermissionDL:BaseDL<Permission>, IPermissionDL
    {
        public async Task<ServiceResponse> GetByRoleID(int roleID)
        {
            //Chuẩn bị câu lệnh sql
            string sql = $"SELECT * FROM permission p INNER JOIN `role-permission` r ON p.PermissionID = r.PermissionID WHERE r.RoleID = {roleID}";

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.QueryAsync<List<Permission>>(sql);

                if (res != null)
                {
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = res
                    };
                }
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }
    }
}
