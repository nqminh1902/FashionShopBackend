using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class EliminateReason : BaseEnities
    {
        [Key]
        public int EliminateReasonID { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }

    }
}
