using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Detalle_Compras
{
    public interface IObtenerDetalleCompraAD
    {
        Task<IEnumerable<DetalleCompraDto>> Obtener(int idVenta);
    }
}
