using FashionShopCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class RecruitmentPeriod:BaseEnities
    {
        public int RecruitmentPeriodID { get; set; }
        public string PeriodName { get; set; }
        public int RecruitmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ReportPeriod { get; set; }
        public int Quantity { get; set; }
    }
}
