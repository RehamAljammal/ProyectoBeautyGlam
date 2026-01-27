using BeautyGlam.Abstracciones.AccesoADatos.Producto.RegistrarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.RegistrarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.RegistrarProducto;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Productos.RegistrarProducto
{
    public class RegistrarProductoLN : IRegistrarProductoLN
    {
        private IRegistrarProductoAD _registrarProductoAD;

        public RegistrarProductoLN()
        {
            _registrarProductoAD = new RegistrarProductoAD();
        }

        public async Task<int> Registrar(ProductosDTO elProductoParaGuardar)
        {
            elProductoParaGuardar.estado = true;

            int cantidadDeFilasAfectadas =
                await _registrarProductoAD.Registrar(elProductoParaGuardar);

            return cantidadDeFilasAfectadas;
        }
    }
}
