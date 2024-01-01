using FashionShopBL.BaseBL;
using FashionShopBL.EmailBL;
using FashionShopCommon;
using FashionShopCommon.Enums;
using FashionShopDL.CandidateDL;
using FashionShopDL.EmailDL;
using FashionShopDL.RecruitmentDetailDL;
using FashionShopDL.WorkExperientDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.CandidateBL
{
    public class CandidateBL:BaseBL<Candidate>, ICandidateBL
    {
        private ICandidateDL _candidateDL;
        private IWorkExperientDL _workExperientDL;
        private IRecruitmentDetailDL _recruitmentDetailDL;
        private IEmailBL _emailBL;
        public CandidateBL(ICandidateDL candidateDL, IWorkExperientDL workExperientDL, IRecruitmentDetailDL recruitmentDetailDL, IEmailBL emailBL) : base(candidateDL) 
        {
            _workExperientDL = workExperientDL;
            _candidateDL = candidateDL;
            _recruitmentDetailDL = recruitmentDetailDL;
            _emailBL = emailBL;
        }

        public async Task<ServiceResponse> GetByIDs(List<int> ids)
        {
            return await _candidateDL.GetByIDs(ids);
        }

        public override async Task<ServiceResponse> InsertRecord(Candidate record)
        {
            var res = await _candidateDL.InsertRecord(record);

            if (res != null && res.Success)
            {
                if(record.WorkExperients != null && record.WorkExperients.Count > 0)
                {
                    foreach(var item in record.WorkExperients)
                    {
                        item.CandidateID = (int)res.Data;
                    }
                    await _workExperientDL.InsertMultipleRecord(record.WorkExperients);
                }

                if (record.RecruitmentDetail != null)
                {
                    record.RecruitmentDetail.CandidateID = (int)res.Data;
                    record.RecruitmentDetail.ChannelID = (int)record.ChannelID;
                    record.RecruitmentDetail.ApplyDate = DateTime.Now;
                    await _recruitmentDetailDL.InsertRecord(record.RecruitmentDetail);
                    if (!string.IsNullOrEmpty(record.Email))
                    {
                        _ = Task.Run(() =>
                        {
                            _emailBL.SendEmail(record.Email, EmailType.EmailRecruitment, record);
                        });

                    }
                }
            }

            return res;
        }

        public override async Task<ServiceResponse> UpdateRecord(int recordID, Candidate record)
        {
            var res = await base.UpdateRecord(recordID, record);

            if (res != null && res.Success)
            {
                if (record.WorkExperients != null && record.WorkExperients.Count > 0)
                {
                    foreach (var item in record.WorkExperients)
                    {
                        if(item.State == StateEnum.Insert)
                        {
                            item.CandidateID = recordID;
                            await _workExperientDL.InsertRecord(item);
                        }else if(item.State == StateEnum.Update)
                        {
                            await _workExperientDL.UpdateRecord((int)item.WorkExperientID, item);
                        }else if( item.State == StateEnum.Delete)
                        {
                            await _workExperientDL.DeleteRecord((int)item.WorkExperientID);
                        }
                    }
                }
            }

            return res;
        }
    }
}
