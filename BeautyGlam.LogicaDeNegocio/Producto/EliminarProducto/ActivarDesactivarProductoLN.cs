using BeautyGlam.Abstracciones.AccesoADatos.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ActivarDesactivarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.EliminarProducto;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Productos.EliminarProducto
{
   public class ActivarDesactivarProductoLN : IActivarDesactivarProductoLN
{
    private readonly ActivarDesactivarProductoAD _eliminarProductoAD;

    public ActivarDesactivarProductoLN()
    {
        _eliminarProductoAD = new ActivarDesactivarProductoAD();
    }

    public async Task<int> ActivarDesactivar(ProductosDTO elProductoParaGuardar)
    {
        // Cambiar el estado del producto
        return await _eliminarProductoAD.ActivarDesactivar(elProductoParaGuardar); 
    }
}
}
