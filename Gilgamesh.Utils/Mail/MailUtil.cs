using System;
using System.Net.Mail;

namespace Gilgamesh.Utils.Mail
{
    public class MailUtil
    {
        public static void SendMail(string to, string mailObject, string mailBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                var mailFrom = System.Configuration.ConfigurationManager.AppSettings["mailAdressFrom"];
                var mailLogin = System.Configuration.ConfigurationManager.AppSettings["mailCredentialsLogin"];
                var mailPass = System.Configuration.ConfigurationManager.AppSettings["mailCredentialsPassword"];
                

                mail.From = new MailAddress(mailFrom);
                mail.To.Add(to);
                mail.Subject = mailObject;
                mail.Body =  mailBody;

                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential(mailLogin, mailPass);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}