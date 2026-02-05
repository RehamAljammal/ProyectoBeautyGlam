using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Producto.EditarProducto
{
    public interface IEditarProductoAD
    {
        Task<int> Editar(ProductosDTO elProductoParaGaurdar);
        Task<ProductosDTO> ObtenerPorId(int id);
    }
}
