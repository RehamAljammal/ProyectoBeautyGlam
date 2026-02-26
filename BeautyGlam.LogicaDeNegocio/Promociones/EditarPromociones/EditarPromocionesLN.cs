using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EditarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.EditarPromociones;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Promociones.EditarPromociones
{
    public class EditarPromocionesLN : IEditarpromocionesLN
    {
        private EditarPromocionesAD _editarPromocionesAD;

        public EditarPromocionesLN()
        {
            _editarPromocionesAD = new EditarPromocionesAD();
        }

        public async Task<int> Editar(PromocionesDTO laPromocionParaGuardar)
        {
            int cantidadDeFilasAfectas =
                await _editarPromocionesAD.Editar(laPromocionParaGuardar);

            return cantidadDeFilasAfectas;
        }

        public async Task<PromocionesDTO> ObtenerPorId(int id)
        {
            return await _editarPromocionesAD.ObtenerPorId(id);
        }
    }
}
