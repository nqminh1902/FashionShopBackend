using FashionShopBL.BaseBL;
using FashionShopBL.CandidateBL;
using FashionShopBL.EmailBL;
using FashionShopCommon;
using FashionShopCommon.Entities.DTO;
using FashionShopCommon.Enums;
using FashionShopCommon.ExtentionMethod;
using FashionShopDL.CandidateScheduleDetailDL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.CandidateScheduleDetailBL
{
    public class CandidateScheduleDetailBL:BaseBL<CandidateScheduleDetail>, ICandidateScheduleDetailBL
    {
        private ICandidateScheduleDetailDL _candidateScheduleDetailDL;
        private IEmailBL _emailBL;
        private ICandidateBL _candidateBL;
        public CandidateScheduleDetailBL(ICandidateScheduleDetailDL candidateScheduleDetailDL, IEmailBL emailBL, ICandidateBL candidateBL) :base(candidateScheduleDetailDL)
        {
            _candidateScheduleDetailDL = candidateScheduleDetailDL;
            _emailBL = emailBL;
            _candidateBL = candidateBL;
        }

        public override async Task<ServiceResponse> GetPaging(PagingRequest pagingRequest)
        {
            var param = BuildWhereParameter(pagingRequest);
            var startDate = pagingRequest.CustomParam?["startDate"];
            var endDate = pagingRequest.CustomParam?["endDate"];
            if (startDate != null && endDate != null)
            {
                var l = startDate.ToString();
                var r = endDate.ToString();
                param.Add("v_StartDate", DateTime.Parse(l));
                param.Add("v_EndDate", DateTime.Parse(r));
                param.Add("v_RecruitmentID", 0);
            }

            var pagingResult = await _candidateScheduleDetailDL.GetPaging(param);
            if (pagingResult.TotalCount > 0)
            {
                return new ServiceResponse()
                {
                    Success = true,
                    Data = pagingResult
                };
            }
            return new ServiceResponse()
            {
                Success = false,
                Data = pagingResult
            };
        }

        public async Task<ServiceResponse> GetSheduleDetailByRecruitment(PagingRequest pagingRequest)
        {
            var param = BuildWhereParameter(pagingRequest);
            var startDate = pagingRequest.CustomParam?["startDate"];
            var endDate = pagingRequest.CustomParam?["endDate"];
            var recruitmentID = pagingRequest.CustomParam?["recruitmentID"];
            var periodID = pagingRequest.CustomParam?["periodID"];
            if (startDate != null && endDate != null && periodID != null && recruitmentID != null)
            {
                var s = startDate.ToString();
                var e = endDate.ToString();
                var r = recruitmentID.ToString();
                var p = periodID.ToString();

                param.Add("v_StartDate", DateTime.Parse(s));
                param.Add("v_EndDate", DateTime.Parse(e));
                param.Add("v_RecruitmentID", Int32.Parse(r));
                param.Add("v_PeriodID", Int32.Parse(p));
            }
            return await _candidateScheduleDetailDL.GetSheduleDetailByRecruitment(param);
           
        }

        public override async Task<ServiceResponse> InsertRecord(CandidateScheduleDetail record)
        {
            return await base.InsertRecord(record);
        }

        public override async Task<ServiceResponse> UpdateRecord(int recordID, CandidateScheduleDetail record)
        {
            var res = await base.UpdateRecord(recordID, record);

            if (res.Success && record.IsNotifyCandidate)
            {
                var data = await _candidateBL.GetRecordByID(record.CandidateID);
                Candidate can = (Candidate)data.Data;
                if (can != null && !string.IsNullOrEmpty(can.Email))
                {
                    _ = Task.Run(() =>
                    {
                        var candidate = new
                        {
                            ScheduleName = record.ScheduleName,
                            JobPositionName = record.JobPositionName,
                            CandidateName = can.CandidateName,
                            EvaluationDate = record.StartTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                            StartTime = record.StartTime.ToString("HH:mm"),
                            Address = record.Address,
                            Room = record.Room,
                        };
                        if (record.ScheduleType == 3)
                        {
                            _emailBL.SendEmail(can.Email, EmailType.EmailTraning, record);
                        }
                        else
                        {
                           _emailBL.SendEmail(can.Email, EmailType.EmailInterview, record);
                        }
                    });
                }
            }

            return res;
        }
    }
}
