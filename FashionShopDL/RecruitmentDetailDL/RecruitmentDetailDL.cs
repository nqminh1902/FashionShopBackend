using Dapper;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Entities.DTO;
using FashionShopDL.BaseDL;
using FashionShopDL.CandidateDL;
using FashionShopDL.RecruitmentDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.RecruitmentDetailDL
{
    public class RecruitmentDetailDL: BaseDL<RecruitmentDetail>, IRecruitmentDetailDL
    {
        public async Task<ServiceResponse> getTotalCandidateByRound(int recruitmentID, int status, int period)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_GetRound";
            var parameter = new DynamicParameters();
            parameter.Add("v_RecruitmentID", recruitmentID);
            parameter.Add("v_Status", status);
            parameter.Add("v_RecruitmentPeriod", period);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResult = await mysqlConnection.QueryMultipleAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResult != null)
                {
                    var listData = multipleResult.Read<object>().ToList();
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = listData
                    };
                }
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }

        public async Task<ServiceResponse> ChangeRound(int id, RecruitmentRound round)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_ChangeRound";
            var parameter = new DynamicParameters();
            parameter.Add("v_RecruitmentRoundID", round.RecruitmentRoundID);
            parameter.Add("v_RecruitmentRoundName", round.RecruitmentRoundName);
            parameter.Add("v_CandidateID", id);
            parameter.Add("v_RecruitmentID", round.RecruitmentID);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.ExecuteAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (res > 0)
                {
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = null
                    };
                }
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }


        public async Task<ServiceResponse> GetEliminate()
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_GetEliminate";
            var parameter = new DynamicParameters();

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.QueryAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<ServiceResponse> EliminateCandiadte(int recordId, int id, int recruitmentID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_EliminateCandiadte";
            var parameter = new DynamicParameters();
            parameter.Add("v_recordID", recordId);
            parameter.Add("v_candidateID", id);
            parameter.Add("v_recruitmentID", recruitmentID);


            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.QueryFirstOrDefaultAsync<int>(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<ServiceResponse> TransferToEmployee(int recordId, int id, int recruitmentID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_Employee";
            var parameter = new DynamicParameters();
            parameter.Add("v_recordID", recordId);
            parameter.Add("v_candidateID", id);
            parameter.Add("v_recruitmentID", recruitmentID);


            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.QueryFirstOrDefaultAsync<int>(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<ServiceResponse> getByCandidateID(int id)
        {
            //Chuẩn bị câu lệnh sql
            string sql = $"SELECT r.*, r1.Title FROM `recruitment-detail` r LEFT JOIN recruitment r1 ON r.RecruitmentID = r1.RecruitmentID WHERE r.CandidateID = {id};";


            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.QueryAsync(sql);

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

        public async Task<ServiceResponse> ContinueRecruit(int id, int recruitmentID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_ContinueRecruit";
            var parameter = new DynamicParameters();
            parameter.Add("v_candidateID", id);
            parameter.Add("v_recruitmentID", recruitmentID);


            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.ExecuteAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<ServiceResponse> RemoveFromRecruitment(int id, int recruitmentID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_RemoveFromRecruitment";
            var parameter = new DynamicParameters();
            parameter.Add("v_candidateID", id);
            parameter.Add("v_recruitmentID", recruitmentID);


            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res =  await mysqlConnection.ExecuteAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<ServiceResponse> RevokeEmployee(int id, int recruitmentID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_RecruitmentDetail_RevokeEmployee";
            var parameter = new DynamicParameters();
            parameter.Add("v_candidateID", id);
            parameter.Add("v_recruitmentID", recruitmentID);


            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var res = await mysqlConnection.ExecuteAsync(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<ServiceResponse> ChangeRecruitment(int id, int recruitmentID, int recruitmentRound, int choose, int period)
        {
            MySqlTransaction transaction = null;
            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                //Chuẩn bị câu lệnh sql
                string storeProcedureName = "Proc_RecruitmentDetail_ChangeRecruitment";
                mysqlConnection.Open();
                transaction = mysqlConnection.BeginTransaction();
                var parameter = new DynamicParameters();
                parameter.Add("v_candidateID", id);
                parameter.Add("v_recruitmentID", recruitmentID);
                parameter.Add("v_recruitmentRoundID", recruitmentRound);
                parameter.Add("v_recruitmentPeriodID", period != 0 ? period : null);
                parameter.Add("v_choose", choose);
                var res = await mysqlConnection.QueryFirstOrDefaultAsync<int>(storeProcedureName, parameter, transaction, commandType: System.Data.CommandType.StoredProcedure);
                if (res != 0)
                {
                    transaction.Commit();
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = res
                    };
                }
                transaction.Rollback();

                
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }
    }
}
