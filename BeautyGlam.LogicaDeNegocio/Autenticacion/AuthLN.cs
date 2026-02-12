using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Usuario;
using BeautyGlam.LogicaDeNegocio.Seguridad;

namespace BeautyGlam.LogicaDeNegocio.Autenticacion
{
    public class AuthLN
    {
        private readonly UsuarioAuthAD _usuarioAuthAD;
        private readonly UsuarioRegistroAD _usuarioRegistroAD;
        private readonly PasswordHasher _hasher;

        public AuthLN()
        {
            _usuarioAuthAD = new UsuarioAuthAD();
            _usuarioRegistroAD = new UsuarioRegistroAD();
            _hasher = new PasswordHasher();
        }

        public UsuarioAuthDTO Validar(string correo, string contrasena)
        {
            UsuarioAuthDTO usuario = _usuarioAuthAD.ObtenerPorCorreo(correo);

            if (usuario == null) return null;
            if (usuario.estado == false) return null;

            bool ok = _hasher.Verificar(contrasena, usuario.passwordSalt, usuario.passwordHash);
            if (ok == false) return null;

            return usuario;
        }

      
        // Devuelve null si todo bien, o un mensaje de error si falla
        public string Registrar(RegisterDTO model)
        {
            if (_usuarioRegistroAD.ExisteCorreo(model.correo))
            {
                return "Ya existe un usuario con ese correo.";
            }

            if (_usuarioRegistroAD.ExisteUsername(model.username))
            {
                return "Ese username ya está en uso.";
            }

            byte[] salt = _hasher.GenerarSalt();
            byte[] hash = _hasher.GenerarHash(model.contrasena, salt);

            _usuarioRegistroAD.Insertar(model, salt, hash);

            return null;
        }
    }
}
