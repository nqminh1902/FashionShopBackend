using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class JobPosition : BaseEnities
    {
        [Key]
        public int JobPositionID { get; set; }
        public string JobPositionCode { get; set; }
        public string JobPositionName { get; set; }
        public int Status { get; set; }


    }
}
