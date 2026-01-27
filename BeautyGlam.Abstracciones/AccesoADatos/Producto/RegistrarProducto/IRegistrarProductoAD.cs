using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Producto.RegistrarProducto
{
    public interface IRegistrarProductoAD
    {
        Task<int> Registrar(ProductosDTO elProductoParaGuardar);

    }
}
