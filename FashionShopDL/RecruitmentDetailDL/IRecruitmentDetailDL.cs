using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.RecruitmentDetailDL
{
    public interface IRecruitmentDetailDL: IBaseDL<RecruitmentDetail>
    {
        public Task<ServiceResponse> getTotalCandidateByRound(int recruitmentID, int status, int period);

        public Task<ServiceResponse> ChangeRound(int id, RecruitmentRound round);

        public Task<ServiceResponse> GetEliminate();
        public Task<ServiceResponse> EliminateCandiadte(int recortID, int item, int recruitmentID);

        public Task<ServiceResponse> TransferToEmployee(int recortID, int item, int recruitmentID);
        public Task<ServiceResponse> getByCandidateID(int id);
        public Task<ServiceResponse> ContinueRecruit(int id, int recruitmentID);
        public Task<ServiceResponse> RemoveFromRecruitment(int id, int recruitmentID);
        public Task<ServiceResponse> RevokeEmployee(int id, int recruitmentID);
        public Task<ServiceResponse> ChangeRecruitment(int id, int recruitmentID, int recruitmentRound, int choose, int period);

    }
}
