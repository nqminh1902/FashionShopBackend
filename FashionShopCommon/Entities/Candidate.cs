using FashionShopCommon.Entities;
using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class Candidate:BaseEnities
    {
        [Key]
        public int? CandidateID { get; set; }
        public string? CandidateName { get; set;}
        public string? Avatar { get; set; } = "";
        public string? ChannelName { get; set; } = "";
        public int? ChannelID { get; set; } = 0;
        public Gender Gender { get; set;}
        public int? Active { get; set;} = 1;
        public string? Mobile { get; set;} 
        public DateTime? ApplyDate { get; set;} = null;
        public DateTime? Birthday { get; set;}
        public string? Email { get; set;}
        public string? Address { get; set; }
        public int? CandidateStatusID { get; set; } = null;
        public string? CandidateStatusName { get;set;} = null;
        public string? AttachmentCV { get; set; } = null;
        public string? AttachmentName { get; set; } = null;
        public int? EducationDegreeID { get; set;} = null;
        public string? EducationDegreeName { get; set; } = null;
        public int? EducationPlaceID { get; set; } = null;
        public string? EducationPlaceName { get; set; } = null;
        public int? EducationMajorID { get; set; } = null;
        public string? EducationMajorName { get; set; } = null;
        public string? WorkPlaceRecent { get;set; } = null;
        public int? RecruitmentRoundID { get; set; } = null;
        public string? RecruitmentRoundName { get; set; } = null;
        public int? ReasonRemoveID { get; set; } = null;
        public string? ReasonRemoveName { get; set; } = null;
        public int? JobPositionID { get; set; } = null;
        public string? JobPositionName { get; set; } = null;
        public int? RecruitmentID { get; set; } = null;
        public string? RecruitmentName { get; set; } = null;
        public int? IsEmployee { get; set; } = null;
        public string? Facebook { get; set; } = null;
        public string? Zalo { get; set; } = null;

        [DetailTable]
        public List<WorkExperient>? WorkExperients { get; set; }
        [DetailTable]
        public RecruitmentDetail? RecruitmentDetail { get; set; }
    }
}
