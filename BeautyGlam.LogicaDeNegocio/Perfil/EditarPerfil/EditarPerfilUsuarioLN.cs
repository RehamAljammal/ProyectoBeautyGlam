using BeautyGlam.Abstracciones.AccesoADatos.Usuario.Perfil;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.Perfil;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Usuario.Perfil;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Usuario.Perfil
{
    public class EditarPerfilUsuarioLN : IEditarPerfilUsuarioLN
    {
        private readonly IEditarPerfilUsuarioAD _editarPerfilUsuarioAD;

        public EditarPerfilUsuarioLN()
        {
            _editarPerfilUsuarioAD = new EditarPerfilUsuarioAD();
        }

        public EditarPerfilUsuarioLN(IEditarPerfilUsuarioAD editarPerfilUsuarioAD)
        {
            _editarPerfilUsuarioAD = editarPerfilUsuarioAD;
        }

        public async Task<int> Editar(UsuarioDto usuario)
        {
            return await _editarPerfilUsuarioAD.Editar(usuario);
        }

        public async Task<UsuarioDto> ObtenerPorId(int id)
        {
            return await _editarPerfilUsuarioAD.ObtenerPorId(id);
        }
    }
}