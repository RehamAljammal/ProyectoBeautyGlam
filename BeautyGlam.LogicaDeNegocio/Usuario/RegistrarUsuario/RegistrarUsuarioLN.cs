using BeautyGlam.Abstracciones.AccesoADatos.Usuario.RegistrarUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.RegistrarUsuario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Usuario.RegistrarUsuario;
using BeautyGlam.LogicaDeNegocio.Seguridad;
using System;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Usuario.RegistrarUsuario
{
    public class RegistrarUsuarioLN : IRegistrarUsuarioLN
    {
        private readonly IRegistrarUsuarioAD _ad;
        private readonly PasswordHasher _hasher;

        public RegistrarUsuarioLN()
        {
            _ad = new RegistrarUsuarioAD();
            _hasher = new PasswordHasher();
        }

        public async Task<int> Registrar(UsuarioCrearDto elUsuario)
        {
            if (elUsuario == null)
                throw new ArgumentNullException(nameof(elUsuario));

            // 🔐 Hash + Salt correctos
            byte[] salt = _hasher.GenerarSalt();
            byte[] hash = _hasher.GenerarHash(elUsuario.contrasena, salt);

            // Defaults de seguridad (por si vienen vacíos)
            if (string.IsNullOrWhiteSpace(elUsuario.rol))
                elUsuario.rol = "Usuario";

            elUsuario.estado = true;

            return await _ad.Registrar(elUsuario, hash, salt);
        }
    }
}
