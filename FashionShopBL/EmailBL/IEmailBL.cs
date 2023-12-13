using FashionShopCommon;
using FashionShopCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.EmailBL
{
    public interface IEmailBL
    {
        public ServiceResponse SendEmail(string receiverEmail, EmailType emailType, object model);
    }
}
