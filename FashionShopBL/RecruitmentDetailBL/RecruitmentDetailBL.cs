using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.RecruitmentDetailDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RecruitmentDetailBL
{
    public class RecruitmentDetailBL: BaseBL<RecruitmentDetail>, IRecruitmentDetailBL
    {
        private IRecruitmentDetailDL _recruitmentDetail;
        public RecruitmentDetailBL(IRecruitmentDetailDL recruitmentDetailDL) : base(recruitmentDetailDL)
        {
            _recruitmentDetail = recruitmentDetailDL;
        }
    }
}
