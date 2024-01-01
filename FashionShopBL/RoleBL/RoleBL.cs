using FashionShopBL.BaseBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Enums;
using FashionShopDL.RoleDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.RoleBL
{
    public class RoleBL: BaseBL<Role>, IRoleBL
    {
        private IRoleDL _roleDL;
        public RoleBL(IRoleDL roleDL):base(roleDL)
        {
            _roleDL = roleDL;
        }

        public async Task<ServiceResponse> SaveRole(Role role)
        {
            var res = new ServiceResponse();    
            if (role.State == StateEnum.Insert)
            {
                res = await _roleDL.InsertRecord(role);
                if (res.Success && role.Permissions != null)
                {
                    var roleID = (int)res.Data;
                    foreach (var permission in role.Permissions)
                    {
                        var rolePermission = new RolePermission()
                        {
                            RoleID = roleID,
                            PermissionID = permission.PermissionID
                        };
                        _ = await _roleDL.InsertRolePermission(rolePermission);
                    }
                }
            }
            else
            {
                res = await _roleDL.UpdateRecord(role.RoleID, role);
                if (res.Success && role.Permissions != null)
                {
                    _ = await _roleDL.DeleteRolePermission(role.RoleID);
                    foreach (var permission in role.Permissions)
                    {
                        var rolePermission = new RolePermission()
                        {
                            RoleID = role.RoleID,
                            PermissionID = permission.PermissionID
                        };
                        _ = await _roleDL.InsertRolePermission(rolePermission);
                    }
                }
            }


            return res;
        }
    }
}
