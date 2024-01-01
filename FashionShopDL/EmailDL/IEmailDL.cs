using FashionShopCommon;
using FashionShopCommon.Entities;
using FashionShopCommon.Enums;
using FashionShopDL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopDL.EmailDL
{
    public interface IEmailDL : IBaseDL<Email>
    {
        public Task SendEmail(string emailContent, string emailSubject, string emailAddress);

        public Task<Email> GetEmailByType(EmailType type);


    }
}
