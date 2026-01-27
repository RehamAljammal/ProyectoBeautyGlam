using BeautyGlam.Abstracciones.AccesoADatos.Inventario.ListaDeInventario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                (from i in _elContexto.Inventario
                 join p in _elContexto.Producto
                     on i.idProducto equals p.id
                 select new InventarioDto
                 {
                     idInventario = i.idInventario,
                     stockActual = i.stockActual,
                     stockMinimo = i.stockMinimo,
                     stockMaximo = i.stockMaximo,
                     idProducto = p.id,
                     nombre = p.nombre
                 }).ToList();

            return laListaDeInventario;
        }

    }
}
