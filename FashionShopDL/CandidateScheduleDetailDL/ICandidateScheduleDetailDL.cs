using Dapper;
using FashionShopCommon;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.CandidateScheduleDetailDL
{
    public interface ICandidateScheduleDetailDL: IBaseDL<CandidateScheduleDetail>
    {
        public Task<ServiceResponse> GetSheduleDetailByRecruitment(DynamicParameters parameters);
    }
}
