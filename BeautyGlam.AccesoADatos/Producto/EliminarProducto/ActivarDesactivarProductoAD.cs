using BeautyGlam.Abstracciones.AccesoADatos.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ActivarDesactivarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Producto.EliminarProducto
{
    public class ActivarDesactivarProductoAD : IActivarDesactivarProductoAD
    {
        private Contexto _contexto;

        public ActivarDesactivarProductoAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> ActivarDesactivar(ProductosDTO elProductoParaGuardar)
        {
            ProductoAD elProductoEnBaseDeDatos = _contexto.Producto
                .FirstOrDefault(x => x.id == elProductoParaGuardar.id);

            if (elProductoEnBaseDeDatos != null)
            {
                elProductoEnBaseDeDatos.estado = !elProductoEnBaseDeDatos.estado; // Activar/Desactivar
                return await _contexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}