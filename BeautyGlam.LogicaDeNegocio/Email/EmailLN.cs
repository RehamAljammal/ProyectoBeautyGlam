using BeautyGlam.Abstracciones.LogicaDeNegocio.Email;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Email
{
    public class EmailLN : IEmailLN
    {
        public async Task Enviar(string para, string asunto, string htmlBody)
        {
            if (string.IsNullOrWhiteSpace(para)) throw new ArgumentNullException("para");

            string host = ConfigurationManager.AppSettings["SMTP_Host"];
            int puerto = int.Parse(ConfigurationManager.AppSettings["SMTP_Puerto"]);
            bool ssl = bool.Parse(ConfigurationManager.AppSettings["SMTP_SSL"]);

            string usuario = ConfigurationManager.AppSettings["SMTP_Usuario"];
            string clave = ConfigurationManager.AppSettings["SMTP_Clave"];
            string desde = ConfigurationManager.AppSettings["SMTP_Desde"];

            using (SmtpClient smtp = new SmtpClient(host, puerto))
            {
                smtp.EnableSsl = ssl;
                smtp.Credentials = new NetworkCredential(usuario, clave);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(desde, "BeautyGlam");
                    mail.To.Add(para);
                    mail.Subject = asunto;
                    mail.Body = htmlBody;
                    mail.IsBodyHtml = true;

                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
