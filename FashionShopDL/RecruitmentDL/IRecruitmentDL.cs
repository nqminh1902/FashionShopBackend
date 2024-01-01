using FashionShopCommon;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.RecruitmentDL
{
    public interface IRecruitmentDL: IBaseDL<Recruitment>
    {
        public Task<ServiceResponse> getRecruitmentBroad(int recruitmentID);
        public Task<ServiceResponse> updateRecruitmentStatus(int recruitmentID, int status);
    }
}
