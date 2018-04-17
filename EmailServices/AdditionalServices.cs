using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.IO;

namespace AdditionalServices
{
    public class AdditionalServices
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
        public byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");

        public string Encripta(string Cadena, string Key)
        {
            byte[] Clave = Encoding.ASCII.GetBytes(Key);
            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }



        public string Desencripta(string Cadena, string Key)
        {
            byte[] Clave = Encoding.ASCII.GetBytes(Key);
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }
    }
}
