using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopDL.PermissionDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.PermissionBL
{
    public class PermissionBL:BaseBL<Permission>, IPermissionBL
    {
        private IPermissionDL _permissionDL;
        public PermissionBL(IPermissionDL permissionDL):base(permissionDL)
        {
            _permissionDL = permissionDL;
        }

        public async Task<ServiceResponse> GetByRoleID(int roleID)
        {
            return await _permissionDL.GetByRoleID(roleID);
        }
    }
}
