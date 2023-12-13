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
        public ServiceResponse getTotalCandidateByRound(int recruitmentID, int status, int period);

        public ServiceResponse ChangeRound(ChangeRoundDTO datas);

        public ServiceResponse GetEliminate();
        public ServiceResponse EliminateCandiadte(int recortID, List<int> ids, int recruitmentID, bool isSendMail);
        public ServiceResponse TransferToEmployee(int recortID, List<int> ids, int recruitmentID);
        public ServiceResponse RevokeEmployee(List<int> ids, int recruitmentID);
        public ServiceResponse ContinueRecruit(List<int> ids, int recruitmentID);
        public ServiceResponse RemoveFromRecruitment(List<int> ids, int recruitmentID);
        public ServiceResponse getByCandidateID(int id);
        public ServiceResponse ChangeRecruitment(List<int> ids, int recruitmentID, int recruitmentRound, int choose, int period);
    }
}
