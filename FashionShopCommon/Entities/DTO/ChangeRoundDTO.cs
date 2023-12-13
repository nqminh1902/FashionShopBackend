using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class ChangeRoundDTO
    {
        public List<int> ids { get; set; }
        public RecruitmentRound recruitmentRound { get; set; }
    }
}
