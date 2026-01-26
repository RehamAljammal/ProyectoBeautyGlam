using BeautyGlam.Abstracciones.AccesoADatos.Marca.EditarMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EditarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marca.EditarMarca;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Marca.EditarMarca
{
    public class EditarMarcaLN : IEditarMarcaLN
    {
        private IEditarMarcaAD _editarMarcaAD;

        public EditarMarcaLN()
        {
            _editarMarcaAD = new EditarMarcaAD();
        }

        public async Task<int> Editar(MarcaDto laMarcaParaGuardar)
        {

            int cantidadDeFilasAfectas = await _editarMarcaAD.Editar(laMarcaParaGuardar);
            return cantidadDeFilasAfectas;
        }

        public async Task<MarcaDto> ObtenerPorId(int id)
        {
            return await _editarMarcaAD.ObtenerPorId(id);
        }
    }
}

