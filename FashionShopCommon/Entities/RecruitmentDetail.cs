using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class RecruitmentDetail
    {
        [Key]
        public int RecruitmentDetailID { get; set; }
        public int RecruitmentID { get; set; }
        public int CandidateID { get; set; }
        public int RecruitmentRoundID { get; set; }
        public int Status { get; set; }
        public DateTime? StartTime { get; set; }
        public int ChannelID { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? ReasonRemoved { get; set; }
        public int? ReasonRemovedID { get; set; }
        public string? RecruitmentRoundName { get; set; }
        public DateTime? TransferRoundDate { get; set; }
        public DateTime? EliminatedTime { get; set; }
        public DateTime? TransferEmployeeDate { get; set; }
        public int RecruitmentPeriodID { get; set; }
        [CancelUpdate]
        public string? CandidateName { get; set; }
        [CancelUpdate]
        public Gender Gender { get; set; }
        [CancelUpdate]
        public string? Mobile { get; set; }
        [CancelUpdate]
        public string? Birthday { get; set; }
        [CancelUpdate]
        public string? Email { get; set; }
        [CancelUpdate]
        public string? Address { get; set; }
        [CancelUpdate]
        public string? ChannelName { get; set; }
        [CancelUpdate]
        public string? EducationDegreeName { get; set; }
        [CancelUpdate]
        public string? EducationPlaceName { get; set; }
        [CancelUpdate]
        public string? EducationMajorName { get; set; }
        [CancelUpdate]
        public string? WorkPlaceRecent { get; set; }
        [CancelUpdate]
        public string? RecruitmentName { get; set; }
        public int? IsEmployee { get; set; }
        [CancelUpdate]
        public string? Avatar { get; set; }
        [CancelUpdate]
        public int? JobPositionID { get; set; }
        [CancelUpdate]
        public string? JobPositionName { get; set; }
    }
}
