using FashionShopCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.ReportDL
{
    public interface IReportDL
    {
        public Task<ServiceResponse> GetCandidateByTime(int recruitmentID, DateTime startDate, DateTime endDate, int? periodID);

        public Task<IEnumerable> RecruitmentEfficiency(int recruitmentID, int periodID);

        public Task<IEnumerable> RecruitmentChannel(int recruitmentID, int periodID);
    }
}
