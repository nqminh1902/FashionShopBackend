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

namespace FashionShopDL.RoleDL
{
    public class RoleDL: BaseDL<Role>, IRoleDL
    {
        public async Task<ServiceResponse> InsertRolePermission(RolePermission rolePermission)
        {
            //Chuẩn bị câu lệnh sql
            string sql = $"INSERT INTO `role-permission` (RoleID, PermissionID) VALUE ({rolePermission.RoleID}, {rolePermission.PermissionID});";

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.ExecuteAsync(sql);

                if (res > 0)
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
        public async Task<ServiceResponse> DeleteRolePermission(int RoleID)
        {
            //Chuẩn bị câu lệnh sql
            string sql = $"DELETE FROM `role-permission` WHERE RoleID = {RoleID};";

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.ExecuteAsync(sql);

                if (res > 0)
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

        public override async Task<ServiceResponse> GetRecordByID(int recordID)
        {
            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = "Proc_Role_GetByID";

            var parameters = new DynamicParameters();
            parameters.Add($"v_RoleID", recordID);


            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var multipleResult = await mySqlConnection.QueryMultipleAsync(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (multipleResult != null)
                {
                    var role = multipleResult.Read<Role>().Single();
                    var permissions = multipleResult.Read<Permission>().ToList();
                    return new ServiceResponse()
                    {
                        Data = new
                        {
                            role,
                            permissions
                        },
                        Success = true
                    };
                }
                return new ServiceResponse()
                {
                    Data = null,
                    Success = false
                };
            }
        }
    }
}
