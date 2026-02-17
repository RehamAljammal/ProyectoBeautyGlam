using BeautyGlam.Abstracciones.AccesoADatos.Usuario.EditarUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.EditarUsuario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Usuario.EditarUsuario;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Usuario.EditarUsuario
{
    public class EditarUsuarioLN : IEditarUsuarioLN
    {
        private readonly IEditarUsuarioAD _ad;

        public EditarUsuarioLN()
        {
            _ad = new EditarUsuarioAD();
        }

        public async Task<UsuarioDto> ObtenerPorId(int id)
        {
            UsuarioDto usuario = await _ad.ObtenerPorId(id);
            return usuario;
        }

        public async Task<int> Editar(UsuarioDto elUsuarioParaGuardar)
        {
            int filas = await _ad.Editar(elUsuarioParaGuardar);
            return filas;
        }
    }
}
