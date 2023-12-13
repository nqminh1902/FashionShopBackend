using FashionShopCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopCommon.Entities
{
    public class Email
    {
        public int EmailID { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public EmailType EmailType { get; set; }
    }
}
