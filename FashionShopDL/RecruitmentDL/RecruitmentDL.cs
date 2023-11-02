using Dapper;
using FashionShopCommon;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.RecruitmentDL
{
    public class RecruitmentDL: BaseDL<Recruitment>, IRecruitmentDL
    {
        public override ServiceResponse GetRecordByID(int recordID)
        {
            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = "Proc_Recruitment_GetByID";

            var parameters = new DynamicParameters();
            parameters.Add($"v_RecruitmentID", recordID);


            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var multipleResult = mySqlConnection.QueryMultiple(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (multipleResult != null)
                {
                    var recruitment = multipleResult.Read<Recruitment>().SingleOrDefault();
                    if(recruitment != null)
                    {
                        recruitment.RecruitmentPeriods = multipleResult.Read<RecruitmentPeriod>().ToList();
                        recruitment.RecruitmentRounds = multipleResult.Read<RecruitmentRound>().ToList();
                    }

                    return new ServiceResponse()
                    {
                        Data = recruitment,
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
