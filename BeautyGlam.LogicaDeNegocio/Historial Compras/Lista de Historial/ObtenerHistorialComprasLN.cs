using BeautyGlam.Abstracciones.LogicaDeNegocio.Historial_de_Compras.Lista_Historial;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.HistorialCompras.Lista_de_Historial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Historial_Compras.Lista_de_Historial
{
    public class ObtenerHistorialComprasLN : IObtenerHistorialComprasLN
    {
        private readonly ObtenerHistorialComprasAD _ad;

        public ObtenerHistorialComprasLN()
        {
            _ad = new ObtenerHistorialComprasAD();
        }

        public async Task<IEnumerable<HistorialCompraDto>> Obtener(int idUsuario)
        {
            return await _ad.Obtener(idUsuario);
        }
    }
}
