using BeautyGlam.Abstracciones.AccesoADatos.Usuario.RegistrarUsuario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Usuario.RegistrarUsuario
{
    public class RegistrarUsuarioAD : IRegistrarUsuarioAD
    {
        private readonly Contexto _elContexto;

        public RegistrarUsuarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(
            UsuarioCrearDto elUsuario,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            if (elUsuario == null)
                throw new ArgumentNullException(nameof(elUsuario));

            UsuarioAD nuevo = new UsuarioAD
            {
                nombre = elUsuario.nombre,
                apellido = elUsuario.apellido,
                username = elUsuario.username,
                correo = elUsuario.correo,
                telefono = elUsuario.telefono,
                direccion = elUsuario.direccion,

                fecha_Registro = DateTime.Now,

                passwordHash = passwordHash,
                passwordSalt = passwordSalt,

                rol = elUsuario.rol,
                estado = elUsuario.estado
            };

            _elContexto.Usuario.Add(nuevo);
            return await _elContexto.SaveChangesAsync();
        }
    }
}
