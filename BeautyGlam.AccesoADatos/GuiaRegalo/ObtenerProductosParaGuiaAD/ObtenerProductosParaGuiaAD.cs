using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia
{
    public class ObtenerProductosParaGuiaAD : IObtenerProductosParaGuiaAD
    {
        private Contexto _contexto;

        public ObtenerProductosParaGuiaAD()
        {
            _contexto = new Contexto();
        }

        public List<ProductoSeleccionadoDto> Obtener()
        {
            return _contexto.Producto
                .Where(p => p.estado == true)
                .Select(p => new ProductoSeleccionadoDto
                {
                    id = p.id,
                    nombre = p.nombre,
                    imagen = p.imagen,
                    precio = p.precio
                })
                .ToList();
        }
    }
}
