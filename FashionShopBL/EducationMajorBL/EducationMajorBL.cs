using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.EducationMajorDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.EducationMajorBL
{
    public class EducationMajorBL:BaseBL<EducationMajor>, IEducationMajorBL
    {
        private IEducationMajorDL _educationMajorDL;
        public EducationMajorBL(IEducationMajorDL educationMajorDL):base(educationMajorDL)
        {
            _educationMajorDL = educationMajorDL;
        }
    }
}
