using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class User
    {
        [Key]
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }
        public int? RoleID { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Mobile { get; set; }
        public DateTime? BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public int? JobPositionID { get; set; }
        public string? JobPositionName { get; set; }
        public bool IsUser { get; set; }
        public string? EmailOffice { get; set; }
        public int? Status { get; set; }
        public string? Avatar { get; set; }
        public bool IsSendActive { get; set; }
    }
}
