﻿using FashionShopBL.BaseBL;
using FashionShopCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.CandidateBL
{
    public interface ICandidateBL:IBaseBL<Candidate>
    {
        public Task<ServiceResponse> GetByIDs(List<int> ids);
    }
}
