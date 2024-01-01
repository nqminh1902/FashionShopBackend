using FashionShopBL.BaseBL;
using FashionShopBL.CandidateBL;
using FashionShopBL.EmailBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Enums;
using FashionShopCommon.ExtentionMethod;
using FashionShopDL.CandidateDL;
using FashionShopDL.RecruitmentDetailDL;
using Newtonsoft.Json;
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
        private ICandidateDL _candidateDL;
        private IEmailBL _emailBL;
        public RecruitmentDetailBL(IRecruitmentDetailDL recruitmentDetailDL, ICandidateDL candidateDL, IEmailBL emailBL) : base(recruitmentDetailDL)
        {
            _recruitmentDetail = recruitmentDetailDL;
            _candidateDL = candidateDL;
            _emailBL = emailBL;
        }

        public async Task<ServiceResponse> getTotalCandidateByRound(int recruitmentID, int status, int period)
        {
            return await _recruitmentDetail.getTotalCandidateByRound(recruitmentID, status, period);
        }

        public async Task<ServiceResponse> ChangeRound(ChangeRoundDTO datas)
        {
            var result = new ServiceResponse();
            var ids = datas.ids;
            var recruitmentRound = datas.recruitmentRound;

            if (ids != null && recruitmentRound != null)
            {
                foreach (var id in ids)
                {
                    var res = await _recruitmentDetail.ChangeRound(id, recruitmentRound);
                    if(res.Success == false)
                    {
                        result.Success = false;
                        return result;
                    }
                }
            }
            result.Success = true;
            return result;
        }

        public async Task<ServiceResponse> GetEliminate()
        {
           
           return await _recruitmentDetail.GetEliminate();
        }

        public async Task<ServiceResponse> EliminateCandiadte(int recortID, List<int> ids, int recruitmentDetailID, bool isSendMail)
        {
            foreach (var item in ids)
            {
                var res = await _recruitmentDetail.EliminateCandiadte(recortID, item, recruitmentDetailID);
                if (res.Success && isSendMail)
                {
                    var can = await _recruitmentDetail.GetRecordByID((int)res.Data);
                    RecruitmentDetail recruitmentDetail = (RecruitmentDetail)can.Data;
                    if (can.Success && !string.IsNullOrEmpty(recruitmentDetail.Email))
                    {
                        _ = Task.Run(() => { 
                            _emailBL.SendEmail(recruitmentDetail.Email, EmailType.EmailEliminate, recruitmentDetail);
                        });
                    }
                }
            }

            return new ServiceResponse()
            {
                Success = true,
                Data = null
            };

        }

        public async Task<ServiceResponse> TransferToEmployee(int recortID, List<int> ids, int recruitmentID)
        {
            foreach (var item in ids)
            {
                var res = await _recruitmentDetail.TransferToEmployee(recortID, item, recruitmentID);
                if (res.Success)
                {
                    var can = await _recruitmentDetail.GetRecordByID((int)res.Data);
                    RecruitmentDetail recruitmentDetail = (RecruitmentDetail)can.Data;
                    if (can.Success && !string.IsNullOrEmpty(recruitmentDetail.Email))
                    {
                        _ = Task.Run(() => { 
                            var mergedata = new
                            {
                                CandidateName = recruitmentDetail.CandidateName,
                                JobPositionName = recruitmentDetail.JobPositionName
                            };
                            _emailBL.SendEmail(recruitmentDetail.Email, EmailType.EmailEmployee, mergedata);
                        });
                    }
                }
            }

            return new ServiceResponse()
            {
                Success = true,
                Data = null
            };

        }

        public async Task<ServiceResponse> getByCandidateID(int id)
        {

            return await _recruitmentDetail.getByCandidateID(id);

        }

        public async Task<ServiceResponse> RevokeEmployee(List<int> ids, int recruitmentID)
        {
            foreach (var item in ids)
            {
                var res = await _recruitmentDetail.RevokeEmployee(item, recruitmentID);
                if (res.Success == false)
                {
                    return res;
                }
            }

            return new ServiceResponse()
            {
                Success = true,
                Data = null
            };

        }

        public async Task<ServiceResponse> RemoveFromRecruitment(List<int> ids, int recruitmentID)
        {
            foreach (var item in ids)
            {
                var res = await _recruitmentDetail.RemoveFromRecruitment(item, recruitmentID);
                if (res.Success == false)
                {
                    return res;
                }
            }

            return new ServiceResponse()
            {
                Success = true,
                Data = null
            };

        }

        public async Task<ServiceResponse> ContinueRecruit(List<int> ids, int recruitmentID)
        {
            foreach (var item in ids)
            {
                var res = await _recruitmentDetail.ContinueRecruit(item, recruitmentID);
                if (res.Success == false)
                {
                    return res;
                }
            }

            return new ServiceResponse()
            {
                Success = true,
                Data = null
            };

        }

        public async Task<ServiceResponse> ChangeRecruitment(List<int> ids, int recruitmentID, int recruitmentRound, int choose, int period)
        {
            foreach (var id in ids)
            {
                var res = await _recruitmentDetail.ChangeRecruitment(id, recruitmentID, recruitmentRound, choose, period);
                if (res.Success)
                {
                    var can = await _recruitmentDetail.GetRecordByID((int)res.Data);
                    RecruitmentDetail recruitmentDetail = (RecruitmentDetail)can.Data;
                    if (can.Success && !string.IsNullOrEmpty(recruitmentDetail.Email))
                    {
                        _ = Task.Run(() =>
                        {
                            _emailBL.SendEmail(recruitmentDetail.Email, EmailType.EmailRecruitment, recruitmentDetail);
                        });
                    }
                }
            }
            return new ServiceResponse()
            {
                Success = true,
                Data = null
            };
        }
    }
}
