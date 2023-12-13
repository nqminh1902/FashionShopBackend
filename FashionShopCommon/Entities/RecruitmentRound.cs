using FashionShopCommon.Entities;
using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class RecruitmentRound : BaseEnities
    {
        public int RecruitmentRoundID { get; set; }
        public string RecruitmentRoundName { get; set; }
        [CancelUpdate]
        public string? RecruitmentRoundColor { get; set; }
        [CancelUpdate]
        public int RecruitmentID { get; set; }
        [CancelUpdate]
        public bool IsSystem { get; set; }
        public int SordOrder { get; set; }
        [CancelUpdate]
        public bool IsHired { get; set; }


    }
}
