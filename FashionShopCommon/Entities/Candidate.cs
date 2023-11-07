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
        public int? CandidateID { get; set; }
        public string? CandidateName { get; set;}
        public string? Avatar { get; set;}
        public string? ChannelName { get; set;}
        public int? ChannelID { get; set; }
        public Gender Gender { get; set;}
        public int? Active { get; set;}
        public string? Mobile { get; set;}
        public DateTime? ApplyDate { get; set;}
        public DateTime? Birthday { get; set;}
        public string? Email { get; set;}
        public string? Address { get; set;}
        public int? CandidateStatusID { get; set; }
        public string? CandidateStatusName { get;set;}
        public string? AttachmentCV { get; set; }
        public string? AttachmentName { get; set; }
        public int? EducationDegreeID { get; set;}
        public string? EducationDegreeName { get; set; }
        public int? EducationPlaceID { get; set; } 
        public string? EducationPlaceName { get; set; }
        public int? EducationMajorID { get; set; }
        public string? EducationMajorName { get; set; }
        public string? WorkPlaceRecent { get;set; }
        public int? RecruitmentRoundID { get; set; }
        public string? RecruitmentRoundName { get; set; }
        public int? ReasonRemoveID { get; set; }
        public string? ReasonRemoveName { get; set; }
        public int? JobPositionID { get; set; }
        public string? JobPositionName { get; set; }
        public int? RecruitmentID { get; set; }
        public string? RecruitmentName { get; set; }
        public int? IsEmployee { get; set; }
        public string? Facebook { get; set; }
        public string? Zalo { get; set; }

        [DetailTable]
        public List<WorkExperient>? WorkExperients { get; set; }
    }
}
