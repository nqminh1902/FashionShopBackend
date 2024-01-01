using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RoleBL
{
    public interface IRoleBL: IBaseBL<Role>
    {
        public Task<ServiceResponse> SaveRole(Role role);
    }
}
