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

        public override ServiceResponse DeleteMultiple(List<int> ids)
        {
            MySqlTransaction transaction = null;

            var str = string.Join("','", ids);

            //Chuẩn bị câu lệnh SQL
            string sql = $" DELETE FROM candiate WHERE CandidateID IN ('{str}'); DELETE FROM recruitment-detail WHERE CandidateID IN ('{str}');";

            int numberOfRowsAffected = 0;

            // Khời tạo kết nối tới DB MySQL
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                try
                {
                    transaction = mySqlConnection.BeginTransaction();
                    //Thực hiện gọi vào DB
                    numberOfRowsAffected = mySqlConnection.Execute(sql, transaction: transaction);
                    if (numberOfRowsAffected == ids.Count)
                    {
                        transaction.Commit();

                    }
                    else
                    {

                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    mySqlConnection.Close();
                }
            }

            //Xử lý kết quả trả về

            //Thành công: Trả về Id nhân viên thêm thành công
            if (numberOfRowsAffected > 0)
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = ids
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = ids
            };
        }
    }
}
