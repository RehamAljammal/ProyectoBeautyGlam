using BeautyGlam.Abstracciones.AccesoADatos.Inventario;
using BeautyGlam.Abstracciones.AccesoADatos.Producto.RegistrarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using BeautyGlam.AccesoADatos.Inventario;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Producto.RegistrarProducto
{
    public class RegistrarProductoAD : IRegistrarProductoAD
    {
        private readonly Contexto _elContexto;
        private readonly RegistrarInventarioAD _registrarInventarioAD;

        public RegistrarProductoAD()
        {
            _elContexto = new Contexto();

            // ✅ MISMO CONTEXTO
            _registrarInventarioAD = new RegistrarInventarioAD(_elContexto);
        }

        public async Task<int> Registrar(ProductosDTO elProductoParaGuardar)
        {
            using (var transaccion = _elContexto.Database.BeginTransaction())
            {
                try
                {
                    // ===== VALIDAR SI EXISTE =====
                    ProductoAD registroExistente =
                        _elContexto.Producto.FirstOrDefault(p => p.id == elProductoParaGuardar.id);

                    if (registroExistente != null)
                    {
                        if (!registroExistente.estado)
                        {
                            registroExistente.nombre = elProductoParaGuardar.nombre;
                            registroExistente.descripcion = elProductoParaGuardar.descripcion;
                            registroExistente.precio = elProductoParaGuardar.precio;
                            registroExistente.imagen = elProductoParaGuardar.imagen;
                            registroExistente.idCategoria = elProductoParaGuardar.idCategoria;
                            registroExistente.idMarca = elProductoParaGuardar.idMarca;
                            registroExistente.idProveedor = elProductoParaGuardar.idProveedor;
                            registroExistente.estado = true;

                            await _elContexto.SaveChangesAsync();
                            transaccion.Commit();
                            return registroExistente.id;
                        }

                        return 0;
                    }

                    // ===== CREAR PRODUCTO =====
                    ProductoAD nuevoProducto = ConvierteObjetoAEntidad(elProductoParaGuardar);
                    _elContexto.Producto.Add(nuevoProducto);
                    await _elContexto.SaveChangesAsync();

                    // ===== CREAR INVENTARIO AUTOMÁTICO =====
                    InventarioAD inventario = new InventarioAD
                    {
                        id = nuevoProducto.id,   // FK Producto
                        stockActual = 0,
                        stockMinimo = 0,
                        stockMaximo = 0
                    };

                    _elContexto.Inventario.Add(inventario);
                    await _elContexto.SaveChangesAsync();

                    // ===== CONFIRMAR TODO =====
                    transaccion.Commit();

                    return nuevoProducto.id;
                }
                catch
                {
                    // ❌ SI FALLA ALGO → ROLLBACK
                    transaccion.Rollback();
                    throw; // deja que la capa superior maneje el error
                }
            }
        }

        private ProductoAD ConvierteObjetoAEntidad(ProductosDTO elProductoParaGuardar)
        {
            return new ProductoAD
            {
                nombre = elProductoParaGuardar.nombre,
                descripcion = elProductoParaGuardar.descripcion,
                precio = elProductoParaGuardar.precio,
                imagen = elProductoParaGuardar.imagen,
                idCategoria = elProductoParaGuardar.idCategoria,
                idMarca = elProductoParaGuardar.idMarca,
                idProveedor = elProductoParaGuardar.idProveedor,
                estado = true
            };
        }
    }
}
