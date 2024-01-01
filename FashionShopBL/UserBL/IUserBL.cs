using FashionShopBL.BaseBL;
using FashionShopCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.UserBL
{
    public interface IUserBL: IBaseBL<User>
    {
        public User Login(User user);
    }
}
