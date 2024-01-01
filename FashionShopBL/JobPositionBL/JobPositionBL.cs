using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.JobPositionDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.JobPositionBL
{
    public class JobPositionBL:BaseBL<JobPosition>, IJobPositionBL
    {
        private IJobPositionDL _JobPosition;
        public JobPositionBL(IJobPositionDL jobPositionDL):base(jobPositionDL)
        {
            _JobPosition = jobPositionDL;
        }
    }
}
