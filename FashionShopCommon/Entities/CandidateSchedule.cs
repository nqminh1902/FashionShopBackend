using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class CandidateSchedule
    {
        [Key]
        public int CandidateScheduleID { get; set; }
        public int RecruitmentID { get; set; }
        public string RecruitmentTitle { get; set; }
        public string ScheduleName { get; set; }
        public int ScheduleType { get; set; }
        public int RecruitmentRoundID { get; set; }
        public DateTime EvaluationDate { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Room { get; set; }
        public string Address { get; set; }
        public int AddressID { get; set; }
        public string Note { get; set; }
        public bool IsNotifyCandidate { get; set; }
        public string? JobPositionName { get; set; }

        public bool IsNotifyCouncil { get; set; }

        [DetailTable]
        public List<CandidateScheduleDetail>? candidateScheduleDetails { get; set; }
        [DetailTable]
        public List<RecruitmentBroad>? recruitmentBroads { get; set; }
    }
}
