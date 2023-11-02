using FashionShopCommon.Entities;
using FashionShopCommon.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon
{
    public class Recruitment : BaseEnities
    {
        public int RecruitmentID { get; set; }
        public string? Title { get; set; }
        public int? JobPositionID { get; set; }
        public string? JobPositionName { get; set; }
        public int? Quantity { get; set; }
        public int? WorkType { get; set; }
        public DateTime? RegistrationExpiryDate { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string? SalaryContent { get; set; }
        public int? CurrencyCodeID { get; set; }
        public string? Description { get; set; }
        public int? ContactID { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPosition { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMobile { get; set; }
        public string? Requirement { get; set; }
        public string? Benefit { get; set; }
        public string? Summary { get; set; }
        public DateTime? ReportPeriod { get; set; }
        public int? PlanType { get; set; }
        public int? ActualQuantity { get; set; }
        public DateTime? ExpectedTime { get; set; }
        public int? RankID { get; set; }
        public string? RankName { get; set; }
        public int? CarrerID { get; set; }
        public string? CarrerName { get; set; }

        public int? WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        [DetailTable]
        public List<RecruitmentRound>? RecruitmentRounds { get; set; }
        [DetailTable]
        public List<RecruitmentPeriod>? RecruitmentPeriods { get; set; }
    }
}
