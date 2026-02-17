using BeautyGlam.Abstracciones.AccesoADatos.Email;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;

namespace BeautyGlam.AccesoADatos.Email
{
    public class EmailServicioAD : IEmailServicioAD
    {
        public async Task Enviar(string paraCorreo, string asunto, string htmlCuerpo)
        {
            string host = ConfigurationManager.AppSettings["SMTP_Host"];
            int puerto = int.Parse(ConfigurationManager.AppSettings["SMTP_Puerto"]);
            string usuario = ConfigurationManager.AppSettings["SMTP_Usuario"];
            string clave = ConfigurationManager.AppSettings["SMTP_Clave"];
            bool ssl = bool.Parse(ConfigurationManager.AppSettings["SMTP_SSL"]);
            string desde = ConfigurationManager.AppSettings["SMTP_Desde"];

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(desde, "BeautyGlam");
            msg.To.Add(paraCorreo);
            msg.Subject = asunto;
            msg.Body = htmlCuerpo;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(host, puerto);
            smtp.Credentials = new NetworkCredential(usuario, clave);
            smtp.EnableSsl = ssl;

            await smtp.SendMailAsync(msg);
        }
    }
}
