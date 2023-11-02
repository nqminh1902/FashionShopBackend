using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities.DTO;
using FashionShopCommon.ExtentionMethod;
using FashionShopDL.RecruitmentDL;
using FashionShopDL.RecruitmentPeriodDL;
using FashionShopDL.RecruitmentRoundDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FashionShopBL.RecruitmentBL
{
    public class RecruitmentBL: BaseBL<Recruitment>, IRecruitmentBL
    {
        private IRecruitmentDL _recruitmentDL;
        private IRecruitmentPeriodDL _periodDL;
        private IRecruitmentRoundDL _roundDL;
        public RecruitmentBL(IRecruitmentDL recruitmentDL, IRecruitmentPeriodDL recruitmentPeriodDL, IRecruitmentRoundDL recruitmentRoundDL): base(recruitmentDL)
        {

            _recruitmentDL = recruitmentDL;
            _periodDL = recruitmentPeriodDL;
            _roundDL = recruitmentRoundDL;

        }

        public override ServiceResponse InsertRecord(Recruitment record)
        {
            var res = _recruitmentDL.InsertRecord(record);
            if(res.Success)
            {
                if (record.RecruitmentPeriods != null && record.RecruitmentPeriods.Any())
                {
                    foreach (var item in record.RecruitmentPeriods)
                    {
                        item.RecruitmentID = (int)res.Data;
                    }
                    _periodDL.InsertMultipleRecord(record.RecruitmentPeriods);
                }
                if (record.RecruitmentRounds != null && record.RecruitmentRounds.Any())
                {
                    foreach (var item in record.RecruitmentRounds)
                    {
                        item.RecruitmentID = (int)res.Data;
                    }
                    _roundDL.InsertMultipleRecord(record.RecruitmentRounds);
                }
            }
            return res;
        }

        public override ServiceResponse UpdateRecord(int recordID, Recruitment record)
        {
            var res = base.UpdateRecord(recordID, record);
            if (res.Success)
            {
                if (record.RecruitmentRounds != null && record.RecruitmentRounds.Any())
                {
                    int sordOrder = 1;
                    foreach (RecruitmentRound recruitmentRound in record.RecruitmentRounds)
                    {
                        recruitmentRound.SordOrder = sordOrder;
                        if(recruitmentRound.RecruitmentRoundID == 0)
                        {
                            recruitmentRound.RecruitmentID = recordID;
                            _roundDL.InsertRecord(recruitmentRound);
                        }
                        else
                        {
                            _roundDL.UpdateRecord(recruitmentRound.RecruitmentRoundID, recruitmentRound);
                        }
                        sordOrder++;
                    }

                }
            }
            return res;
        }

        public override ServiceResponse GetPaging(PagingRequest pagingRequest)
        {
            var param = BuildWhereParameter(pagingRequest);
            var pagingResult = _recruitmentDL.GetPaging(param);
            if (pagingResult.Data != null)
            {
                var listRecruitment = (List<Recruitment>)pagingResult.Data;
                foreach (var item in listRecruitment)
                {
                    var customFilter = $"[[\"RecruitmentID\",\"=\",\"{item.RecruitmentID}\"]]";
                    byte[] bytes = Encoding.UTF8.GetBytes(customFilter.Replace("/",""));
                    string base64String = Convert.ToBase64String(bytes);
                    var roundParam = BuildWhereParameter(new PagingRequest() { PageSize = 1000, PageIndex = 1, CustomFilter = base64String, SearchValue = "", SortOrder = new List<string>() { "SordOrder ASC" } });
                    PagingResult round = _roundDL?.GetPaging(roundParam);
                    if (round != null && round.Data != null) {
                        item.RecruitmentRounds = (List<RecruitmentRound>)round.Data;
                    }
                    else
                    {
                        item.RecruitmentRounds = new List<RecruitmentRound>();
                    }

                    var periodParam = BuildWhereParameter(new PagingRequest() { PageSize = 1000, PageIndex = 1, CustomFilter = base64String, SearchValue = "" });
                    PagingResult period = _periodDL?.GetPaging(periodParam);
                    if (period != null && period.Data != null)
                    {
                        item.RecruitmentPeriods = (List<RecruitmentPeriod>)period.Data;
                    }
                    else
                    {
                        item.RecruitmentPeriods = new List<RecruitmentPeriod>();
                    }
                }
            }
            
            return new ServiceResponse()
            {
                Success = true,
                Data = pagingResult
            };
        }
    }
}
