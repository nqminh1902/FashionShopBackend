using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Permission:BaseEnities
    {
        [Key]
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string SubsystemCode { get; set; }
        public string SubsystemName { get; set; }
        public int SordOrder { get; set; }

    }
}
