using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RecruitmentDetailBL
{
    public interface IRecruitmentDetailBL: IBaseBL<RecruitmentDetail>
    {
        public Task<ServiceResponse> getTotalCandidateByRound(int recruitmentID, int status, int period);

        public Task<ServiceResponse> ChangeRound(ChangeRoundDTO datas);

        public Task<ServiceResponse> GetEliminate();
        public Task<ServiceResponse> EliminateCandiadte(int recortID, List<int> ids, int recruitmentID, bool isSendMail);
        public Task<ServiceResponse> TransferToEmployee(int recortID, List<int> ids, int recruitmentID);
        public Task<ServiceResponse> RevokeEmployee(List<int> ids, int recruitmentID);
        public Task<ServiceResponse> ContinueRecruit(List<int> ids, int recruitmentID);
        public Task<ServiceResponse> RemoveFromRecruitment(List<int> ids, int recruitmentID);
        public Task<ServiceResponse> getByCandidateID(int id);
        public Task<ServiceResponse> ChangeRecruitment(List<int> ids, int recruitmentID, int recruitmentRound, int choose, int period);
    }
}
