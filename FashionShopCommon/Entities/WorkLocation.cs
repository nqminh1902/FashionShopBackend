using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class WorkLocation : BaseEnities
    {
        [Key]
        public int WorkLocationID { get; set; }
        public string WorkLocationName { get; set; }
        public int Status { get; set; }

    }
}
