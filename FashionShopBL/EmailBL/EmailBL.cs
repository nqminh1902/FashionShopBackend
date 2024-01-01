using FashionShopCommon;
using FashionShopCommon.Constans;
using FashionShopCommon.Enums;
using FashionShopDL.CandidateDL;
using FashionShopDL.EmailDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShopBL.EmailBL
{
    public class EmailBL : IEmailBL
    {
        private IEmailDL _emailDL;
        public EmailBL(IEmailDL emailDL)
        {
            _emailDL = emailDL;
        }
        public virtual async Task<ServiceResponse> SendEmail(string receiverEmail, EmailType emailType ,object model)
        {

            var emailTempalte = await _emailDL.GetEmailByType(emailType);
            if (emailTempalte != null) {
                var content = ReplaceEmailContent(emailTempalte.EmailContent, model);
                var subject = ReplaceEmailContent(emailTempalte.EmailSubject, model);
                await _emailDL.SendEmail(content, subject, receiverEmail);
                return new ServiceResponse()
                {
                    Success = true,
                };
            }
            return new ServiceResponse()
            {
                Success = false,
            };
        }

        public string ReplaceEmailContent<T>(string content, T model)
        {
            var newContent = content;
            // Lấy rả các Prop của đối tượng
            var properties = model?.GetType().GetProperties();

            foreach (var prop in properties)
            {
                
                if (prop.GetValue(model) != null)
                {
                    string oldstring = $"##{prop.Name}##",
                        newstring = $"{prop.GetValue(model)}";
                    newContent = newContent.Replace(oldstring, newstring);
                }
            }

            return newContent;
        }
    }
}
