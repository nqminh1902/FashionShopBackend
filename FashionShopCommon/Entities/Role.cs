using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Role:BaseEnities
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsAdmin { get; set; }
        [DetailTable]
        public List<Permission>? Permissions { get; set; }
    }
}
