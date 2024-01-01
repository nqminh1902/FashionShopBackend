using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.WorkLocationDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.WorkLocationBL
{
    public class WorkLocationBL:BaseBL<WorkLocation>, IWorkLocationBL
    {
        private IWorkLocationDL _workLocationDL;
        public WorkLocationBL(IWorkLocationDL workLocationDL):base(workLocationDL)
        {
            _workLocationDL = workLocationDL;
        }
    }
}
