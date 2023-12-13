using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class RecruitmentBroad : BaseEnities
    {
        public int RecruitmentBroadID { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public int? RecruitmentID { get; set; }
        public string? Role { get; set; }
        public int? RoleID { get; set; }
        public bool? IsSendMail { get; set; }
    }
}
