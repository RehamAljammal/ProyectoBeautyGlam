using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Producto.EliminarProducto
{
    public interface IEliminarProductoAD
    {
        Task<int> Eliminar(ProductosDTO elProductoParaGuardar);

    }
}
