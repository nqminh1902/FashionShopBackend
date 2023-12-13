using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities.DTO
{
    public class ImportError
    {
        public int Row { get; set; }
        public string ErrorReason { get; set; }
    }
}
