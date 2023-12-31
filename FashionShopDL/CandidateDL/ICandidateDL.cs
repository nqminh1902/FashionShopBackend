﻿using FashionShopCommon;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.CandidateDL
{
    public interface ICandidateDL: IBaseDL<Candidate>
    {
        public Task<ServiceResponse> GetByIDs(List<int> ids);
    }
}
