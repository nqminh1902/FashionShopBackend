using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.RoleDL
{
    public interface IRoleDL: IBaseDL<Role>
    {
        public Task<ServiceResponse> InsertRolePermission(RolePermission rolePermission);

        public Task<ServiceResponse> DeleteRolePermission(int RoleID);
    }
}
