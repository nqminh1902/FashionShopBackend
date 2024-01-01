using FashionShopCommon;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.ImportBL
{
    public interface IImportBL
    {
        public ServiceResponse ValidateImportCandidate(IFormFile formFile);
        public ServiceResponse ValidateEducationMajorImportData(IFormFile formFile);
        public ServiceResponse ValidateUniversityImportData(IFormFile formFile);


    }
}
