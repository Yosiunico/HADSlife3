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

        private string algoritmoEncriptacionHASH = "MD5";
        private int iteraciones = 22;
        private string vectorInicial = "1234567891234567";
        private int tamanoClave = 128;

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

        public string Encripta(string textoCifrar, string palabraPaso)
        {
            string valorRGBSalt = palabraPaso;
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(vectorInicial);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(valorRGBSalt);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoCifrar);

                PasswordDeriveBytes password =
                    new PasswordDeriveBytes(palabraPaso, saltValueBytes,
                        algoritmoEncriptacionHASH, iteraciones);

                byte[] keyBytes = password.GetBytes(tamanoClave / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor =
                    symmetricKey.CreateEncryptor(keyBytes, InitialVectorBytes);

                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream =
                    new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string textoCifradoFinal = Convert.ToBase64String(cipherTextBytes);

                return textoCifradoFinal;
            }
            catch
            {
                return null;
            }
        }
        public string Invertir(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
