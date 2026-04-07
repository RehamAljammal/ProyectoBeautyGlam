using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Historial_de_Compras.Detalle_Compras
{
    public interface IObtenerDetalleCompraLN
    {
        Task<IEnumerable<DetalleCompraDto>> Obtener(int idVenta);
    }
}
