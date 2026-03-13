using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ActivarDesactivarProducto
{
    public interface IActivarDesactivarProductoLN
    {
        Task<int> ActivarDesactivar(ProductosDTO elProductoParaGuardar);
    }
}