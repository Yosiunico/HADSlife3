using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EmailServices
{
    public class EmailServices
    {
        public const string emailemisor = "hads202018@gmail.com";
        public const string passemisor = "Hadslife3";

        public void EnviarEmail(string destinatario, string asunto, string mensaje)
        {
            var dirDe = new MailAddress(emailemisor, emailemisor);
            var dirA = new MailAddress(destinatario, destinatario);
            string dirDePass = passemisor;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(dirDe.Address, dirDePass)
            };

            using (var message = new MailMessage(dirDe, dirA)
            {
                Subject = asunto,
                Body = mensaje
            })
            {
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
        }
    }
}
