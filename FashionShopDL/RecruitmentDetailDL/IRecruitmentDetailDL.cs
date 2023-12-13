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
        public ServiceResponse getTotalCandidateByRound(int recruitmentID, int status, int period);

        public ServiceResponse ChangeRound(int id, RecruitmentRound round);

        public ServiceResponse GetEliminate();
        public ServiceResponse EliminateCandiadte(int recortID, int item, int recruitmentID);

        public ServiceResponse TransferToEmployee(int recortID, int item, int recruitmentID);
        public ServiceResponse getByCandidateID(int id);
        public ServiceResponse ContinueRecruit(int id, int recruitmentID);
        public ServiceResponse RemoveFromRecruitment(int id, int recruitmentID);
        public ServiceResponse RevokeEmployee(int id, int recruitmentID);
        public ServiceResponse ChangeRecruitment(int id, int recruitmentID, int recruitmentRound, int choose, int period);

    }
}
