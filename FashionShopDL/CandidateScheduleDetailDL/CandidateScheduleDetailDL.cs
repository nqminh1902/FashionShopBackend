using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities.DTO;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.CandidateScheduleDetailDL
{
    public class CandidateScheduleDetailDL : BaseDL<CandidateScheduleDetail>, ICandidateScheduleDetailDL
    {
        public async Task<ServiceResponse> GetSheduleDetailByRecruitment(DynamicParameters parameters)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_CandidateScheduleDetail_GetByRecruitment";

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResult = await mysqlConnection.QueryMultipleAsync(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResult != null)
                {
                    var listData = multipleResult.Read<CandidateScheduleDetail>().ToList();
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = listData
                    };
                }
                else
                {
                    return new ServiceResponse()
                    {
                        Success = false,
                        Data = null
                    };
                }
            }
        }
    }
}
