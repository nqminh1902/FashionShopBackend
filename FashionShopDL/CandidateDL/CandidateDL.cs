using Dapper;
using FashionShopCommon;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.CandidateDL
{
    public class CandidateDL: BaseDL<Candidate>, ICandidateDL
    {
        public override ServiceResponse GetRecordByID(int recordID)
        {
            // Chuẩn bị câu lệnh SQL
            string storeProcedureName = "Proc_Candidate_GetByID";

            var parameters = new DynamicParameters();
            parameters.Add($"v_CandidateID", recordID);


            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiên gọi vào DB
                var multipleResult = mySqlConnection.QueryMultiple(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (multipleResult != null)
                {
                    var listData = multipleResult.Read<Candidate>().FirstOrDefault();
                    if(listData != null)
                    {
                        listData.WorkExperients = multipleResult.Read<WorkExperient>().ToList();
                        return new ServiceResponse()
                        {
                            Data = listData,
                            Success = true
                        };
                    }
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
