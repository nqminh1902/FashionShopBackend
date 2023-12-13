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

        public override ServiceResponse InsertRecord(CandidateSchedule record)
        {
            var res = _candidateScheduleDL.InsertRecord(record);
            if (res.Success)
            {
                if (record.candidateScheduleDetails != null && record.candidateScheduleDetails.Any())
                {
                    foreach (var item in record.candidateScheduleDetails)
                    {
                        item.CandidateScheduleID = (int)res.Data;
                    }
                    _candidateScheduleDetailDL.InsertMultipleRecord(record.candidateScheduleDetails);
                }

                if (res.Success && record.IsNotifyCandidate)
                {
                    foreach (var item in record.candidateScheduleDetails)
                    {
                        Candidate can = (Candidate)_candidateBL.GetRecordByID(item.CandidateID).Data;
                        if (can != null && !string.IsNullOrEmpty(can.Email))
                        {
                            var candidate = new
                            {
                                ScheduleName = record.ScheduleName,
                                JobPositionName = record.JobPositionName,
                                CandidateName = can.CandidateName,
                                StartTime = record.StartTime.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                                Address = record.Address,
                                Room = record.Room,
                                CandidateNumber = record.candidateScheduleDetails?.Count
                            };
                            _emailBL.SendEmail(can.Email, EmailType.EmailInterview, candidate);
                        }
                        
                    }
                }

                if (record.IsNotifyCouncil && record.recruitmentBroads != null)
                {
                    foreach(var item in record.recruitmentBroads)
                    {
                        var council = new
                        {
                            ScheduleName = record.ScheduleName,
                            JobPositionName = record.JobPositionName,
                            FullName = item.FullName,
                            StartTime= record.StartTime.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                            Address = record.Address,
                            Room = record.Room,
                            Time = record.StartTime.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                            CandidateNumber = record.candidateScheduleDetails?.Count
                        };
                        _emailBL.SendEmail(item.Email, EmailType.EmailCouncil, council);
                    }
                }
            }
            return res;
        }
    }
}
