using BeautyGlam.Abstracciones.AccesoADatos.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Producto.EliminarProducto
{
    public class EliminarProductoAD : IEliminarProductoAD
    {
        private readonly Contexto _elContexto;

        public EliminarProductoAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Eliminar(ProductosDTO elProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProductoAD elProductoEnBaseDeDatos = _elContexto.Producto
                .FirstOrDefault(ProductoPABuscar =>
                    ProductoPABuscar.id == elProductoParaGuardar.id);

            if (elProductoEnBaseDeDatos != null)
            {
                elProductoEnBaseDeDatos.estado = false;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }
    }
}