using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Usuario
{
    public class UsuarioAuthAD
    {
        private readonly Contexto _elContexto;

        public UsuarioAuthAD()
        {
            _elContexto = new Contexto();
        }

        public UsuarioAuthDTO ObtenerPorCorreo(string correo)
        {
            UsuarioAD entidad = _elContexto.Usuario.FirstOrDefault(u => u.correo == correo);

            if (entidad == null)
            {
                return null;
            }

            UsuarioAuthDTO dto = new UsuarioAuthDTO();
            dto.id_Usuario = entidad.id_Usuario;
            dto.correo = entidad.correo;
            dto.rol = entidad.rol;
            dto.estado = entidad.estado;
            dto.passwordHash = entidad.passwordHash;
            dto.passwordSalt = entidad.passwordSalt;

            return dto;
        }
    }
}
