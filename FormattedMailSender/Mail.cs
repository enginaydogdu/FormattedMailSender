using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace FormattedMailSender
{
    public class Mail
    {
        public void SendMail(string receiver)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["Host"],
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"], ConfigurationManager.AppSettings["SMTPpassword"]),
                Port = int.Parse(ConfigurationManager.AppSettings["Port"])
            };

            using (var message = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], receiver)
            {
                Subject = "Konu",
                Body = CreateBody(),
                IsBodyHtml = true
            })
            {
                smtpClient.Send(message);
            }

                
        }

        private string CreateBody()
        {
            string body = string.Empty;
            using (StreamReader streamReader = new StreamReader(Path.GetFullPath("MailTemplate.html"))
            {

            })

            body = streamReader.ReadToEnd();

            body = body.Replace("{firstname}", "Engin");
            body = body.Replace("{lastname}", "Aydogdu");
            body = body.Replace("{tckn}", "12345678901");

            return body;

        }
    }
}
