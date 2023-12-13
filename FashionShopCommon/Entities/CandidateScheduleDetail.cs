using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class CandidateScheduleDetail
    {
        public int CandidateScheduleDetailID { get; set; }
        public int CandidateID { get; set; }
        public int CandidateScheduleID { get; set; }
        public string CandidateName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Address { get; set; }
        public int AddressID { get; set; }
        public int Duration { get; set; }
        public string Room { get; set; }
        public string Note { get; set; }
        public bool IsNotifyCandidate { get; set; }
        public int ScheduleType { get; set; }
        public bool IsNotifyCouncil { get; set; }
        public string ScheduleName { get; set; }
        public int Gender { get; set; }
        [DetailTable]
        public int RecruitmentID { get; set; }
        [DetailTable]
        public string RecruitmentTitle { get; set; }

    }
}
