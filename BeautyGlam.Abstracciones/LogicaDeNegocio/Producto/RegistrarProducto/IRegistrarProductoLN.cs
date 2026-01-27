using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.RegistrarProducto
{
    public interface IRegistrarProductoLN
    {
        Task<int> Registrar(ProductosDTO elProductoParaGuardar);

    }
}
