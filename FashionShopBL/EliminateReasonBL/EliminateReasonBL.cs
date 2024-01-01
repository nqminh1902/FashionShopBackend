using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using FashionShopDL.EliminateReasonDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.EliminateReasonBL
{
    public class EliminateReasonBL:BaseBL<EliminateReason>, IEliminateReasonBL
    {
        public IEliminateReasonDL _eliminateReasonDL;
        public EliminateReasonBL(IEliminateReasonDL eliminateReasonDL): base(eliminateReasonDL)
        {
            _eliminateReasonDL = eliminateReasonDL;
        }
    }
}
