using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class University : BaseEnities
    {
        public string UniversityName { get; set; }
        [Key]
        public int? UniversityID { get; set; }
        public string UniversityCode { get; set; }

    }
}
