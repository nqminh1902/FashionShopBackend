using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class EducationMajor : BaseEnities
    {
        [Key]
        public int EducationMajorID { get; set; }
        public string EducationMajorName { get; set; }

    }
}
