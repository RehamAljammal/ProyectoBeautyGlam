using BeautyGlam.Abstracciones.AccesoADatos.Usuario.Recuperacion;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Usuario.Recuperacion
{
    public class UsuarioRecuperacionAD : IUsuarioRecuperacionAD
    {
        private readonly Contexto _elContexto;

        public UsuarioRecuperacionAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int?> ObtenerIdUsuarioPorCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return null;

            int? id = await _elContexto.Usuario
                .Where(x => x.correo == correo)
                .Select(x => (int?)x.id_Usuario)
                .FirstOrDefaultAsync();

            return id;
        }

        public async Task<int> ActualizarPassword(int idUsuario, byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash == null) throw new ArgumentNullException("passwordHash");
            if (passwordSalt == null) throw new ArgumentNullException("passwordSalt");

            var usuario = await _elContexto.Usuario.FindAsync(idUsuario);
            if (usuario == null) return 0;

            usuario.passwordHash = passwordHash;
            usuario.passwordSalt = passwordSalt;

            int filas = await _elContexto.SaveChangesAsync();
            return filas;
        }
    }
}
