using Dapper;
using FashionShopCommon;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ReportDL
{
    public class ReportDL : IReportDL
    {
        public ServiceResponse GetCandidateByTime(int recruitmentID, DateTime startDate, DateTime endDate, int? periodID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_Report_CandidateRecruitment";
            var parameter = new DynamicParameters();
            parameter.Add("v_RecruitmentID", recruitmentID);
            parameter.Add("v_StartDate", startDate);
            parameter.Add("v_EndDate", endDate);
            parameter.Add("v_RecruitmentPeriodID", periodID == -1 ? null : periodID);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var multipleResult = mysqlConnection.QueryMultiple(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);

                if (multipleResult != null)
                {
                    var reportData = multipleResult.Read<object>().ToList();
                    var period = multipleResult.Read<object>().ToList();
                    return new ServiceResponse()
                    {
                        Success = true,
                        Data = new
                        {
                            reportData,
                            period
                        }
                    };
                }
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }

        public IEnumerable RecruitmentChannel(int recruitmentID, int periodID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_Report_RecruitmentChannel";
            var parameter = new DynamicParameters();
            parameter.Add("v_RecruitmentID", recruitmentID);
            parameter.Add("v_RecruitmentPeriodID", periodID == -1 ? null : periodID);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var result = mysqlConnection.Query(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable RecruitmentEfficiency(int recruitmentID, int periodID)
        {
            //Chuẩn bị câu lệnh sql
            string storeProcedureName = "Proc_Report_RecruitmentEfficiency";
            var parameter = new DynamicParameters();
            parameter.Add("v_RecruitmentID", recruitmentID);
            parameter.Add("v_RecruitmentPeriodID", periodID == -1 ? null : periodID);

            // Khời tạo kết nối tới DB MySQL
            using (var mysqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var result = mysqlConnection.Query(storeProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
