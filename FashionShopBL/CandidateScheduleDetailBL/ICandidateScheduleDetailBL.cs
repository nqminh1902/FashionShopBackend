using FashionShopBL.BaseBL;
using FashionShopCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.CandidateScheduleDetailBL
{
    public interface ICandidateScheduleDetailBL: IBaseBL<CandidateScheduleDetail>
    {
        public Task<ServiceResponse> GetSheduleDetailByRecruitment(PagingRequest pagingRequest);
    }
}
