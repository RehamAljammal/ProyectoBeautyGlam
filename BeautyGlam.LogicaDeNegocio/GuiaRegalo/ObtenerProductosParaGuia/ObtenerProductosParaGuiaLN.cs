using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia;
using BeautyGlam.Abstracciones.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.Abstracciones.Flujo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio
{
    public class ObtenerProductosParaGuiaLN : IObtenerProductosParaGuiaLN
    {
        private readonly IObtenerProductosParaGuiaAD _obtenerProductosAD;

        public ObtenerProductosParaGuiaLN(IObtenerProductosParaGuiaAD obtenerProductosAD)
        {
            _obtenerProductosAD = obtenerProductosAD;
        }

        public Task<List<ProductoSeleccionadoDto>> Obtener()
        {
            var productos = _obtenerProductosAD.Obtener();

            var resultado = productos.Select(p => new ProductoSeleccionadoDto
            {
                id = p.id,
                nombre = p.nombre,
                imagen = p.imagen,
                precio = p.precio
            }).ToList();

            return Task.FromResult(resultado);
        }

    }
}
