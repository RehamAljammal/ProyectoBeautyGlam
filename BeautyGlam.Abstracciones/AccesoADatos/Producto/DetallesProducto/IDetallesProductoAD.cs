using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Producto.DetallesProducto
{
    public interface IDetallesProductoAD
    {
        Task<int> Detalles(ProductosDTO elProductoParaGuardar);

    }
}
