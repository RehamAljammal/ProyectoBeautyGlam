using BeautyGlam.Abstracciones.AccesoADatos.Recuperacion;
using BeautyGlam.Abstracciones.AccesoADatos.Usuario.Recuperacion;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Email;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Recuperacion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Recuperacion;
using BeautyGlam.AccesoADatos.Usuario.Recuperacion;
using BeautyGlam.LogicaDeNegocio.Email;
using BeautyGlam.LogicaDeNegocio.Seguridad;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeautyGlam.LogicaDeNegocio.Autenticacion
{
    public class RecuperacionContrasenaLN : IRecuperacionContrasenaLN
    {
        private readonly IRecuperacionContrasenaAD _resetAD;
        private readonly IUsuarioRecuperacionAD _usuarioAD;
        private readonly IEmailLN _email;
        private readonly PasswordHasher _hasher;

        public RecuperacionContrasenaLN()
        {
            _resetAD = new RecuperacionContrasenaAD();
            _usuarioAD = new UsuarioRecuperacionAD();
            _email = new EmailLN();
            _hasher = new PasswordHasher();
        }

        public async Task<string> SolicitarToken(string correo, string urlBase)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                return "El correo es requerido.";
            }

            int? idUsuario = await _usuarioAD.ObtenerIdUsuarioPorCorreo(correo);

            if (idUsuario.HasValue == false)
            {
                return "Correo no registrado.";
            }

            string tokenPlano = GenerarTokenSeguro(32);          // token para el link
            byte[] tokenHash = CalcularSha256(tokenPlano);       // lo que guardamos en BD

            DateTime fechaExpira = DateTime.Now.AddMinutes(30);

            int filas = await _resetAD.CrearToken(idUsuario.Value, tokenHash, fechaExpira);
            if (filas <= 0)
            {
                return "No se pudo generar el enlace de recuperación.";
            }

            string tokenUrl = HttpUtility.UrlEncode(tokenPlano);
            string link = urlBase.TrimEnd('/') + "/Auth/RestablecerContrasena?token=" + tokenUrl;

            string asunto = "Recuperación de contraseña - BeautyGlam";
            string body = ConstruirHtmlCorreo(link, fechaExpira);

            await _email.Enviar(correo, asunto, body);

            return "";
        }

        public async Task<string> Restablecer(string token, string nuevaContrasena)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return "Token inválido.";
            }

            if (string.IsNullOrWhiteSpace(nuevaContrasena))
            {
                return "La contraseña es requerida.";
            }

            byte[] tokenHash = CalcularSha256(token);

            ResetVigenteDTO reset = await _resetAD.ObtenerResetVigentePorTokenHash(tokenHash);

            if (reset == null)
            {
                return "El enlace es inválido o ya expiró.";
            }

            byte[] salt = _hasher.GenerarSalt();
            byte[] hash = _hasher.GenerarHash(nuevaContrasena, salt);

            int filas = await _usuarioAD.ActualizarPassword(reset.id_Usuario, hash, salt);
            if (filas <= 0)
            {
                return "No se pudo actualizar la contraseña.";
            }

            await _resetAD.MarcarComoUsado(reset.id_Reset);

            return "";
        }

        private string ConstruirHtmlCorreo(string link, DateTime expira)
        {
            return
                "<div style='font-family:Inter,Arial,sans-serif'>" +
                "<h2>Recuperación de contraseña</h2>" +
                "<p>Haz clic en el siguiente enlace para restablecer tu contraseña:</p>" +
                "<p><a href='" + link + "'>" + link + "</a></p>" +
                "<p>Este enlace expira el: <b>" + expira.ToString("dd/MM/yyyy HH:mm") + "</b></p>" +
                "<p>Si no solicitaste esto, ignora este correo.</p>" +
                "</div>";
        }

        private string GenerarTokenSeguro(int bytes)
        {
            byte[] buffer = new byte[bytes];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }

            // token URL-safe
            string token = Convert.ToBase64String(buffer)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");

            return token;
        }

        private byte[] CalcularSha256(string texto)
        {
            byte[] data = Encoding.UTF8.GetBytes(texto);
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(data); // 32 bytes
            }
        }
    }
}
