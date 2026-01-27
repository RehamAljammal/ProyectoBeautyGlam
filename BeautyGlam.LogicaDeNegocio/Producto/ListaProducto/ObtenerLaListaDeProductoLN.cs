using BeautyGlam.Abstracciones.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ListaProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.ListaProducto;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Productos.ListaProductos
{
    public class ObtenerLaListaDeProductosLN : IObtenerLaListadeProductosLN
    {
        private readonly IObtenerListaDeProductosAD _obtenerListaDeProductosAD;

        public ObtenerLaListaDeProductosLN()
        {
            _obtenerListaDeProductosAD = new ObtenerLaListaDeProductosAD();
        }

        public List<ProductosDTO> Obtener()
        {
            List<ProductosDTO> laListaDeProductos =
                _obtenerListaDeProductosAD.Obtener();

            return laListaDeProductos;
        }
    }
}
