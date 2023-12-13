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
        public ServiceResponse GetCandidateByTime(int recruitmentID, DateTime startDate, DateTime endDate, int? periodID);

        public IEnumerable RecruitmentEfficiency(int recruitmentID, int periodID);

        public IEnumerable RecruitmentChannel(int recruitmentID, int periodID);
    }
}
