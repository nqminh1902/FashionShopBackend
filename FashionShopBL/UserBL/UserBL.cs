using FashionShopBL.BaseBL;
using FashionShopBL.EmailBL;
using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Enums;
using FashionShopDL.UserDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.UserBL
{
    public class UserBL: BaseBL<User>, IUserBL
    {
        private IUserDL _userDL;
        private IEmailBL _emailBL;
        public UserBL(IUserDL userDL, IEmailBL emailBL):base(userDL)
        {
            _userDL = userDL;
            _emailBL = emailBL;
        }

        public override async Task<ServiceResponse> InsertRecord(User record)
        {
            var res = new ServiceResponse();
            if (record.IsUser)
            {
                record.Password = GeneratePassword(10);
            }
            res = await _userDL.InsertRecord(record);

            if(res.Success && record.IsSendActive)
            {
                _ = Task.Run(() => {
                    _emailBL.SendEmail(record.Email, EmailType.EmailActive, record);
                });
            }

            return res;
        }

        public override async Task<ServiceResponse> UpdateRecord(int recordID, User record)
        {
            var res = new ServiceResponse();
            res = await _userDL.UpdateRecord(recordID, record);

            if (res.Success && record.IsSendActive)
            {
                _ = Task.Run(() => {
                    _emailBL.SendEmail(record.Email, EmailType.EmailActive, record);
                });
            }

            return res;
        }

        private string GeneratePassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+";
            var random = new Random();

            string password = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return password;
        }

        public User Login(User user)
        {
            var res = _userDL.Login(user);
            return res;
        }
    }
}
