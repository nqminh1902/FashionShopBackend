using FashionShopCommon;
using FashionShopCommon.ExtentionMethod;
using FashionShopDL.ReportDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.Report
{
    public class ReportBL: IReportBL
    {
        private IReportDL _reportDL;
        public ReportBL(IReportDL reportDL)
        {
            _reportDL = reportDL;
        }

        public ServiceResponse GetCandidateByTime(Dictionary<string, object> request, int recruitmentID)
        {
            var fromDate = request.GetValue("FromDate").ToString();
            var ToDate = request.GetValue("ToDate").ToString();
            var periodID = request.GetValue("periodID").ToString();

            if (fromDate != null && ToDate != null && periodID != null)
            {
                return _reportDL.GetCandidateByTime(recruitmentID, DateTime.Parse(fromDate), DateTime.Parse(ToDate), Int32.Parse(periodID));
            }

            return new ServiceResponse()
            {
                Success = false,
                Data = null
            };
        }

        public ServiceResponse GetDataReportByRecruitment(int recruitmentID, int periodID)
        {
            var recruitmentEfficiency = _reportDL.RecruitmentEfficiency(recruitmentID, periodID);

            var recruitmentChannel = _reportDL.RecruitmentChannel(recruitmentID, periodID);



            return new ServiceResponse()
            {
                Success = true,
                Data = new
                {
                    recruitmentEfficiency,
                    recruitmentChannel
                }
            };
        }
    }
}
