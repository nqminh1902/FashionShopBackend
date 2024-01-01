using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.PermissionDL
{
    public interface IPermissionDL:IBaseDL<Permission>
    {
        public Task<ServiceResponse> GetByRoleID(int roleID);
    }
}
