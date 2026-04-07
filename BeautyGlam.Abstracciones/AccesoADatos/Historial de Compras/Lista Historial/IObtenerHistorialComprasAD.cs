using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Lista_Historial
{
    public interface IObtenerHistorialComprasAD
    {
        Task<IEnumerable<HistorialCompraDto>> Obtener(int idUsuario);
    }
}
