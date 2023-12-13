using FashionShopBL.BaseBL;
using FashionShopCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RecruitmentBL
{
    public interface IRecruitmentBL: IBaseBL<Recruitment>
    {
        public ServiceResponse getRecruitmentBroad(int recruitmentID);
        public ServiceResponse updateRecruitmentStatus(int recruitmentID, int status);
    }
}
