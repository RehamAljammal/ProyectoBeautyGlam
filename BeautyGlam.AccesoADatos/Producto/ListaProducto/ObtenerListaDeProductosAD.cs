using BeautyGlam.Abstracciones.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Producto.ListaProducto
{
    public class ObtenerLaListaDeProductosAD : IObtenerListaDeProductosAD
    {
        private Contexto _elContexto;

        public ObtenerLaListaDeProductosAD()
        {
            _elContexto = new Contexto();
        }

        public List<ProductosDTO> Obtener()
        {
            List<ProductosDTO> laListaDeProductos =
                                                    (from p in _elContexto.Producto
                                                    join c in _elContexto.Categoria on p.idCategoria equals c.id
                                                    join m in _elContexto.Marca on p.idMarca equals m.id_Marca
                                                     join pr in _elContexto.Proveedor on p.idProveedor equals pr.id
                                                    where p.estado == true
                                                    select new ProductosDTO
                                                    {
                                                        id = p.id,
                                                        nombre = p.nombre,
                                                        descripcion = p.descripcion,
                                                        precio = p.precio,
                                                        imagen = p.imagen,
                                                        idCategoria = p.idCategoria,
                                                        nombreCategoria = c.nombre,
                                                        idMarca = p.idMarca,
                                                        nombreMarca = m.nombre,
                                                        idProveedor = p.idProveedor,
                                                        nombreProveedor = pr.nombre,
                                                        estado = p.estado
                                                     }).ToList();

            return laListaDeProductos;
        }
    }
}
