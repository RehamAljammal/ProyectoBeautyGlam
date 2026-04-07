using BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Lista_Historial;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.HistorialCompras.Lista_de_Historial
{
    public class ObtenerHistorialComprasAD : IObtenerHistorialComprasAD
    {
        private readonly Contexto _elContexto;

        public ObtenerHistorialComprasAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<IEnumerable<HistorialCompraDto>> Obtener(int idUsuario)
        {
            var lista = _elContexto.Venta
                .Where(v => v.id_Usuario == idUsuario)
                .Select(v => new HistorialCompraDto
                {
                    idVenta = v.id_Venta,
                    fecha = v.fecha_Venta,
                    total = v.total,
                    estado = v.estado
                });

            return await Task.FromResult(lista.ToList());
        }
    }
}
