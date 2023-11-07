using FashionShopCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class WorkExperient: BaseEnities
    {
        public int? WorkExperientID { get; set; }
        public int CandidateID { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? FromDate { get; set;}
        public DateTime? ToDate { get; set;}
        public string? JobDescription { get; set; }
        public string? JobPosition { get; set; }
    }
}
