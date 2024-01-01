using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopDL.RecruitmentPeriodDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RecruitmentPeriodBL
{
    public class RecruitmentPeriodBL: BaseBL<RecruitmentPeriod>, IRecruitmentPeriodBL
    {
        private IRecruitmentPeriodDL _recruitmentPeriodDL;
        public RecruitmentPeriodBL(IRecruitmentPeriodDL recruitmentPeriodDL) : base(recruitmentPeriodDL)
        {
            _recruitmentPeriodDL = recruitmentPeriodDL;
        }
    }
}
