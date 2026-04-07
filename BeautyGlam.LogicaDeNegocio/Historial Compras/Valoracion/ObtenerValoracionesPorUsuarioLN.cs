using BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Valoracion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.HistorialCompras.Valoración;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Valoracion
{
    public class ObtenerValoracionesPorUsuarioLN
    {
        private readonly IObtenerValoracionesPorUsuarioLN _valoracionesAD;

        public ObtenerValoracionesPorUsuarioLN()
        {
            _valoracionesAD = new ObtenerValoracionesPorUsuarioAD();
        }

        public async Task<IEnumerable<ValoracionDto>> Obtener(int idUsuario)
        {
            return await _valoracionesAD.Obtener(idUsuario);
        }
    }
}