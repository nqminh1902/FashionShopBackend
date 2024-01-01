using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.UniversityDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.UniversityBL
{
    public class UniversityBL:BaseBL<University>, IUniversityBL
    {
        private IUniversityDL _universityDL;
        public UniversityBL(IUniversityDL universityDL): base(universityDL)
        {
            _universityDL = universityDL;
        }
    }
}
