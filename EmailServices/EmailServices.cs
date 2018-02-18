using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mail;

namespace EmailServices
{
    public class EmailServices
    {

        public void EnviarEmail(string destinatario, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.To = destinatario;
            mail.From = "remitente@example.com"; //Aquí iría el correo con el que enviaremos los emails.
            mail.BodyFormat = MailFormat.Html;  //Para enviar email con formato.
            mail.Subject = asunto;
            mail.Body = mensaje;

            try
            {
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = "usuario"; //Aquí iría el correo con el que enviaremos los emails.
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = "clave"; //Aquí iría la contraseña del correo con el que enviaremos los emails.
                SmtpMail.SmtpServer = "smtpserver"; //Servidor smtp que se utilizará para enviar los emails.

                SmtpMail.Send(mail);
            } catch (Exception MailEx) {
                throw new Exception(MailEx.Message);
            }
        }
    }
}
