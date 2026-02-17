using BeautyGlam.Abstracciones.AccesoADatos.Inventario.ListaDeInventario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Inventario
{
    public class ObtenerListaDeInventarioAD : IObtenerListaDeInventarioAD
    {
        private Contexto _elContexto;

        public ObtenerListaDeInventarioAD()
        {
            _elContexto = new Contexto();
        }

        public List<InventarioDto> Obtener()
        {
            List<InventarioDto> laListaDeInventario =
                (from p in _elContexto.Producto
                 join i in _elContexto.Inventario
                     on p.id equals i.id   // INNER JOIN
                 select new InventarioDto
                 {
                     idInventario = i.idInventario,
                     id = p.id,                // 🔥 ID DEL PRODUCTO
                     nombre = p.nombre,
                     stockActual = i.stockActual,
                     stockMinimo = i.stockMinimo,
                     stockMaximo = i.stockMaximo
                 }).ToList();

            return laListaDeInventario;
        }

    }
}
