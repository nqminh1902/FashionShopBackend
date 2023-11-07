using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class RecruitmentDetail
    {
        public int RecruitmentDetailID { get; set; }
        public int RecruitmentID { get; set; }
        public int CandidateID { get; set; }
        public int RecruitmentRoundID { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public int ChannelID { get; set; }
        public string ChannelName { get; set; }
        public DateTime ApplyDate { get; set; }
        public string ReasonRemoved { get; set; }
        public int ReasonRemovedID { get; set; }
        public string RecruitmentRoundName { get; set; }
        public DateTime TransferRoundDate { get; set; }
        public DateTime EliminatedTime { get; set; }
        public DateTime TransferEmployeeDate { get; set; }
        public int RecruitmentPeriodID { get; set; }

    }
}
