using BeautyGlam.Abstracciones.LogicaDeNegocio.Historial_de_Compras.Detalle_Compras;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.HistorialCompras.Detalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Historial_Compras.Detalle
{
    public class ObtenerDetalleCompraLN : IObtenerDetalleCompraLN
    {
        private readonly ObtenerDetalleCompraAD _ad;

        public ObtenerDetalleCompraLN()
        {
            _ad = new ObtenerDetalleCompraAD();
        }

        public async Task<IEnumerable<DetalleCompraDto>> Obtener(int idVenta)
        {
            return await _ad.Obtener(idVenta);
        }
    }
}
