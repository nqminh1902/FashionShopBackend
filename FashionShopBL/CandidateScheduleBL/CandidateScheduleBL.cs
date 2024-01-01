using FashionShopBL.BaseBL;
using FashionShopBL.CandidateBL;
using FashionShopBL.EmailBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Enums;
using FashionShopDL.CandidateScheduleDetailDL;
using FashionShopDL.CandidateScheduleDL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.CandidateScheduleBL
{
    public class CandidateScheduleBL: BaseBL<CandidateSchedule>, ICandidateScheduleBL
    {
        private ICandidateScheduleDL _candidateScheduleDL;
        private ICandidateScheduleDetailDL _candidateScheduleDetailDL;
        private IEmailBL _emailBL;
        private ICandidateBL _candidateBL;
        public CandidateScheduleBL(ICandidateScheduleDL candidateScheduleDL, ICandidateScheduleDetailDL candidateScheduleDetailDL, IEmailBL emailBL, ICandidateBL candidateBL) :base(candidateScheduleDL)
        {
            _candidateScheduleDL = candidateScheduleDL;
            _candidateScheduleDetailDL = candidateScheduleDetailDL;
            _emailBL = emailBL;
            _candidateBL = candidateBL;
        }

        public override async Task<ServiceResponse> InsertRecord(CandidateSchedule record)
        {
            var res = await _candidateScheduleDL.InsertRecord(record);
            if (res.Success)
            {
                if (record.candidateScheduleDetails != null && record.candidateScheduleDetails.Any())
                {
                    foreach (var item in record.candidateScheduleDetails)
                    {
                        item.CandidateScheduleID = (int)res.Data;
                    }
                    await _candidateScheduleDetailDL.InsertMultipleRecord(record.candidateScheduleDetails);
                }

                if (res.Success && record.IsNotifyCandidate)
                {
                    foreach (var item in record.candidateScheduleDetails)
                    {
                        var data = await _candidateBL.GetRecordByID(item.CandidateID);
                        Candidate can = (Candidate)data.Data;
                        if (can != null && !string.IsNullOrEmpty(can.Email))
                        {
                            _ = Task.Run(() => { 
                                var candidate = new
                                {
                                    ScheduleName = record.ScheduleName,
                                    JobPositionName = record.JobPositionName,
                                    CandidateName = can.CandidateName,
                                    EvaluationDate = record.EvaluationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    StartTime = record.StartTime.ToString("HH:mm"),
                                    Address = record.Address,
                                    Room = record.Room
                                };
                                if (record.ScheduleType == 3)
                                {
                                    _emailBL.SendEmail(can.Email, EmailType.EmailTraning, candidate);
                                }
                                else
                                {
                                    _emailBL.SendEmail(can.Email, EmailType.EmailInterview, candidate);
                                }
                            });
                        }
                        
                    }
                }

                if (record.IsNotifyCouncil && record.recruitmentBroads != null)
                {
                    foreach(var item in record.recruitmentBroads)
                    {
                        _ = Task.Run(() =>
                        {
                            var council = new
                            {
                                ScheduleName = record.ScheduleName,
                                JobPositionName = record.JobPositionName,
                                FullName = item.FullName,
                                EvaluationDate = record.EvaluationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                Address = record.Address,
                                Room = record.Room,
                                StartTime = record.StartTime.ToString("HH:mm"),
                                CandidateNumber = record.candidateScheduleDetails?.Count
                            };
                            _emailBL.SendEmail(item.Email, EmailType.EmailCouncil, council);
                        });
                    }
                }
            }
            return res;
        }
    }
}
