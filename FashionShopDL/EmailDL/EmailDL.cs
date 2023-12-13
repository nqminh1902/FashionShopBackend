using Dapper;
using FashionShopCommon;
using FashionShopCommon.Constans;
using FashionShopCommon.Entities;
using FashionShopCommon.Enums;
using FashionShopDL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FashionShopDL.EmailDL
{
    public class EmailDL : BaseDL<Email>, IEmailDL
    {
        public Email GetEmailByType(EmailType type)
        {
            string sql = $"SELECT * FROM `email-template` e WHERE e.EmailType = {(int)type};";

            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                //Thực hiện gọi vào DB
                return mySqlConnection.QueryFirstOrDefault<Email>(sql);
            }
        }

        public void SendEmail(string emailContent, string emailSubject, string receiverEmail)
        {
            string fromMail = EmailInfo.email;
            string passWord = EmailInfo.password;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromMail);
            mailMessage.To.Add(new MailAddress(receiverEmail));
            mailMessage.Subject = emailSubject;
            mailMessage.Body = emailContent;   
            mailMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, passWord),
                EnableSsl = true
            };

            smtpClient.Send(mailMessage);
        }
    }
}
