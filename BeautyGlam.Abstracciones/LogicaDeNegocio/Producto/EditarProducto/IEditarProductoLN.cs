using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EditarProducto
{
    public interface IEditarProductoLN
    {
        Task<int> Editar(ProductosDTO elProductoParaGuardar);

        Task<ProductosDTO> ObtenerPorId(int id);
    }
}
