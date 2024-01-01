using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.PermissionBL
{
    public interface IPermissionBL:IBaseBL<Permission>
    {
        public Task<ServiceResponse> GetByRoleID(int roleID);
    }
}
