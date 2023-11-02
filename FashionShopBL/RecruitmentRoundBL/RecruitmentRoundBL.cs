using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopDL.RecruitmentDL;
using FashionShopDL.RecruitmentRoundDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RecruitmentRoundBL
{
    public class RecruitmentRoundBL: BaseBL<RecruitmentRound>, IRecruitmentRoundBL
    {
        private IRecruitmentRoundDL _recruitmentRoundDL;
        public RecruitmentRoundBL(IRecruitmentRoundDL recruitmentRoundDL) : base(recruitmentRoundDL)
        {

            _recruitmentRoundDL = recruitmentRoundDL;

        }
    }
}
