using FashionShopCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.Report
{
    public interface IReportBL
    {
        public Task<ServiceResponse> GetCandidateByTime(Dictionary<string, object> request, int recruitmentID);

        public Task<ServiceResponse> GetDataReportByRecruitment(int recruitmentID, int periodID);

    }
}
