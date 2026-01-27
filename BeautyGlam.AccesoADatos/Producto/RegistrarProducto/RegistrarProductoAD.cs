using BeautyGlam.Abstracciones.AccesoADatos.Producto.RegistrarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Producto.RegistrarProducto
{
   
    public class RegistrarProductoAD : IRegistrarProductoAD
    {
        private Contexto _elContexto;

        public RegistrarProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ProductosDTO elProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProductoAD registroExistente = _elContexto.Producto
            .FirstOrDefault(ap => ap.id == elProductoParaGuardar.id
             && ap.id == elProductoParaGuardar.id);

            if (registroExistente != null)
            {
                if (!registroExistente.estado)
                {

                }
            }
            else
            {
                ProductoAD nuevoProducto= ConvierteObjetoAEntidad(elProductoParaGuardar);
                _elContexto.Producto.Add(nuevoProducto);
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        private ProductoAD ConvierteObjetoAEntidad(ProductosDTO elProductoParaGuardar)
        {
            return new ProductoAD
            {
                nombre = elProductoParaGuardar.nombre,
                descripcion = elProductoParaGuardar.descripcion,
                precio = elProductoParaGuardar.precio,
                idCategoria = elProductoParaGuardar.idCategoria,
                idMarca = elProductoParaGuardar.idMarca,
                idProveedor = elProductoParaGuardar.idProveedor,
                estado = true
            };
        }
    }
}
