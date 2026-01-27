using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Producto.ObtenerProductoPorId
{
    public class ObtenerProductoPorIdAD
    {
        private Contexto _elContexto;

        public ObtenerProductoPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public ProductosDTO Obtener(int idProductoABuscar)
        {
            ProductosDTO elProductoEnBaseDeDatos =
                (from producto in _elContexto.Producto
                 join categoria in _elContexto.Categoria
                     on producto.idCategoria equals categoria.id into categoriaJoin
                 from categoria in categoriaJoin.DefaultIfEmpty()

                 join marca in _elContexto.Marca
                     on producto.idMarca equals marca.id_Marca into marcaJoin
                 from marca in marcaJoin.DefaultIfEmpty()

                 join proveedor in _elContexto.Proveedor
                     on producto.idProveedor equals proveedor.id into proveedorJoin
                 from proveedor in proveedorJoin.DefaultIfEmpty()

                 where producto.id == idProductoABuscar
                 select new ProductosDTO
                 {
                     id = producto.id,
                     nombre = producto.nombre,
                     descripcion = producto.descripcion,
                     precio = producto.precio,

                     idCategoria = producto.idCategoria,
                     nombreCategoria = categoria == null ? "" : categoria.nombre,

                     idMarca = producto.idMarca,
                     nombreMarca = marca == null ? "" : marca.nombre,

                     idProveedor = producto.idProveedor,
                     nombreProveedor = proveedor == null ? "" : proveedor.nombre,

                     estado = producto.estado
                 }).FirstOrDefault();

            return elProductoEnBaseDeDatos;
        }
    }
}
