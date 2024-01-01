using FashionShopCommon.Entities;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.UserDL
{
    public interface IUserDL: IBaseDL<User>
    {
        public User Login(User user);
    }
}
