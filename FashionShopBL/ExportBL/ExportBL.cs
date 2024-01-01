using FashionShopCommon;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionShopBL.CandidateBL;

namespace FashionShopBL.ExportBL
{
    public class ExportBL : IExportBL
    {
        private ICandidateBL _candidateBL;
        public ExportBL(ICandidateBL candidateBL)
        {
              _candidateBL = candidateBL;
        }
    }
}
