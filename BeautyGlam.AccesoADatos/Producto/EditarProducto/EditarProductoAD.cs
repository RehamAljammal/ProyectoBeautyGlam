using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EditarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Producto.EditarProducto
{
    public class EditarProductoAD : IEditarProductoLN
    {
        private Contexto _elContexto;

        public EditarProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(ProductosDTO elProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProductoAD elProductoEnBaseDeDatos =
                await _elContexto.Producto
                .FirstOrDefaultAsync(p => p.id == elProductoParaGuardar.id);

            if (elProductoEnBaseDeDatos != null)
            {
                elProductoEnBaseDeDatos.nombre = elProductoParaGuardar.nombre;
                elProductoEnBaseDeDatos.descripcion = elProductoParaGuardar.descripcion;
                elProductoEnBaseDeDatos.precio = elProductoParaGuardar.precio;
                elProductoEnBaseDeDatos.imagen = elProductoParaGuardar.imagen;
                elProductoEnBaseDeDatos.idCategoria = elProductoParaGuardar.idCategoria;
                elProductoEnBaseDeDatos.idMarca = elProductoParaGuardar.idMarca;
                elProductoEnBaseDeDatos.idProveedor = elProductoParaGuardar.idProveedor;
                elProductoEnBaseDeDatos.estado = elProductoParaGuardar.estado;
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        public async Task<ProductosDTO> ObtenerPorId(int id)
        {
            ProductoAD entidad = await _elContexto.Producto.FindAsync(id);

            if (entidad == null)
                return null;

            return new ProductosDTO
            {
                id = entidad.id,
                nombre = entidad.nombre,
                descripcion = entidad.descripcion,
                precio = entidad.precio,
                idCategoria = entidad.idCategoria,
                idMarca = entidad.idMarca,
                idProveedor = entidad.idProveedor,
                estado = entidad.estado
            };
        }
    }
}
