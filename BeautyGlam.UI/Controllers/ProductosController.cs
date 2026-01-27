using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.DetallesProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EditarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ListaProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.RegistrarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.ObtenerProductoPorId;

using BeautyGlam.LogicaDeNegocio.Productos.DetallesDeProducto;
using BeautyGlam.LogicaDeNegocio.Productos.EditarProductos;
using BeautyGlam.LogicaDeNegocio.Productos.EliminarProducto;
using BeautyGlam.LogicaDeNegocio.Productos.ListaProductos;
using BeautyGlam.LogicaDeNegocio.Productos.RegistrarProducto;

using BeautyGlam.LogicaDeNegocio.Categorias.ListaDeCategoria;
using BeautyGlam.LogicaDeNegocio.Marca.ListaDeMarca;
using BeautyGlam.LogicaDeNegocio.Proveedores.ListaDeProveedor;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IObtenerLaListadeProductosLN _obtenerLaListaDeProductosLN;
        private readonly IRegistrarProductoLN _agregarProductoLN;
        private readonly IEditarProductoLN _editarProductoLN;
        private readonly IEliminarProductoLN _eliminarProductoLN;
        private readonly IDetallesProductoLN _detallesProductoLN;

        private readonly ObtenerLaListaDeCategoriasLN _obtenerLaListaDeCategoriasLN;
        private readonly ObtenerListaDeMarcaLN _obtenerListaDeMarcaLN;
        private readonly ObtenerLaListaDeProveedoresLN _obtenerLaListaDeProveedoresLN;

        public ProductosController()
        {
            _obtenerLaListaDeProductosLN = new ObtenerLaListaDeProductosLN();
            _agregarProductoLN = new RegistrarProductoLN();
            _editarProductoLN = new EditarProductoLN();
            _eliminarProductoLN = new EliminarProductoLN();
            _detallesProductoLN = new DetallesProductoLN();

            _obtenerLaListaDeCategoriasLN = new ObtenerLaListaDeCategoriasLN();
            _obtenerListaDeMarcaLN = new ObtenerListaDeMarcaLN();
            _obtenerLaListaDeProveedoresLN = new ObtenerLaListaDeProveedoresLN();
        }

        private void CargarCombos(ProductosDTO model = null)
        {
            List<CategoriasDto> categorias = _obtenerLaListaDeCategoriasLN.Obtener();
            List<MarcaDto> marcas = _obtenerListaDeMarcaLN.Obtener();
            List<ProveedoresDto> proveedores = _obtenerLaListaDeProveedoresLN.Obtener();

            ViewBag.Categorias = new SelectList(categorias, "id", "nombre",
                model == null ? (object)null : (object)model.idCategoria);

            ViewBag.Marcas = new SelectList(marcas, "id_Marca", "nombre",
                model == null ? (object)null : (object)model.idMarca);

            ViewBag.Proveedores = new SelectList(proveedores, "id", "nombre",
                model == null ? (object)null : (object)model.idProveedor);
        }

        private string ObtenerTextoPorId<T>(IEnumerable<T> lista, int id, string[] posiblesId, string[] posiblesTexto)
        {
            if (lista == null) return "";

            Type tipo = typeof(T);

            foreach (T item in lista)
            {
                int idEncontrado = 0;
                bool tieneId = false;

                for (int i = 0; i < posiblesId.Length; i++)
                {
                    PropertyInfo propId = tipo.GetProperty(posiblesId[i]);
                    if (propId != null)
                    {
                        object valor = propId.GetValue(item, null);
                        if (valor != null)
                        {
                            int.TryParse(valor.ToString(), out idEncontrado);
                            tieneId = true;
                            break;
                        }
                    }
                }

                if (tieneId && idEncontrado == id)
                {
                    for (int j = 0; j < posiblesTexto.Length; j++)
                    {
                        PropertyInfo propTxt = tipo.GetProperty(posiblesTexto[j]);
                        if (propTxt != null)
                        {
                            object valorTxt = propTxt.GetValue(item, null);
                            return valorTxt == null ? "" : valorTxt.ToString();
                        }
                    }
                }
            }

            return "";
        }

        private void CompletarNombresDelProducto(ProductosDTO producto)
        {
            if (producto == null) return;

            List<CategoriasDto> categorias = _obtenerLaListaDeCategoriasLN.Obtener();
            List<MarcaDto> marcas = _obtenerListaDeMarcaLN.Obtener();
            List<ProveedoresDto> proveedores = _obtenerLaListaDeProveedoresLN.Obtener();

            if (string.IsNullOrWhiteSpace(producto.nombreCategoria))
            {
                producto.nombreCategoria = ObtenerTextoPorId<CategoriasDto>(
                    categorias,
                    producto.idCategoria,
                    new string[] { "id", "id_Categoria", "idCategoria" },
                    new string[] { "nombre", "nombre_Cat", "nombreCat" }
                );
            }

            if (string.IsNullOrWhiteSpace(producto.nombreMarca))
            {
                producto.nombreMarca = ObtenerTextoPorId<MarcaDto>(
                    marcas,
                    producto.idMarca,
                    new string[] { "id_Marca", "id", "idMarca" },
                    new string[] { "nombre", "nombreMarca" }
                );
            }

            if (string.IsNullOrWhiteSpace(producto.nombreProveedor))
            {
                producto.nombreProveedor = ObtenerTextoPorId<ProveedoresDto>(
                    proveedores,
                    producto.idProveedor,
                    new string[] { "id", "id_Proveedor", "idProveedor" },
                    new string[] { "nombre", "nombreProveedor" }
                );
            }
        }

        public ActionResult ListaDeProductos()
        {
            List<ProductosDTO> laListaDeProductos = _obtenerLaListaDeProductosLN.Obtener();
            return View(laListaDeProductos);
        }

        public ActionResult DetallesDelProducto(int id)
        {
            ObtenerProductoPorIdAD obtenerProductoPorIdAD = new ObtenerProductoPorIdAD();
            ProductosDTO producto = obtenerProductoPorIdAD.Obtener(id);

            if (producto == null)
            {
                return RedirectToAction("ListaDeProductos");
            }

            CompletarNombresDelProducto(producto);
            return View(producto);
        }

        public ActionResult CrearProducto()
        {
            CargarCombos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearProducto(ProductosDTO elProductoParaGuardar)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarCombos(elProductoParaGuardar);
                    return View(elProductoParaGuardar);
                }

                await _agregarProductoLN.Registrar(elProductoParaGuardar);
                return RedirectToAction("ListaDeProductos");
            }
            catch
            {
                CargarCombos(elProductoParaGuardar);
                return View(elProductoParaGuardar);
            }
        }

        public ActionResult EditarProducto(int id)
        {
            ObtenerProductoPorIdAD obtenerProductoPorIdAD = new ObtenerProductoPorIdAD();
            ProductosDTO producto = obtenerProductoPorIdAD.Obtener(id);

            if (producto == null)
            {
                return RedirectToAction("ListaDeProductos");
            }

            CargarCombos(producto);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarProducto(ProductosDTO elProductoParaGuardar)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarCombos(elProductoParaGuardar);
                    return View(elProductoParaGuardar);
                }

                ProductosDTO productoActual = await _editarProductoLN.ObtenerPorId(elProductoParaGuardar.id);

                if (productoActual == null)
                {
                    ModelState.AddModelError("", "No existe el producto.");
                    CargarCombos(elProductoParaGuardar);
                    return View(elProductoParaGuardar);
                }

                productoActual.nombre = elProductoParaGuardar.nombre;
                productoActual.descripcion = elProductoParaGuardar.descripcion;
                productoActual.precio = elProductoParaGuardar.precio;
                productoActual.estado = elProductoParaGuardar.estado;
                productoActual.idCategoria = elProductoParaGuardar.idCategoria;
                productoActual.idMarca = elProductoParaGuardar.idMarca;
                productoActual.idProveedor = elProductoParaGuardar.idProveedor;

                await _editarProductoLN.Editar(productoActual);
                return RedirectToAction("ListaDeProductos");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                CargarCombos(elProductoParaGuardar);
                return View(elProductoParaGuardar);
            }
        }

        public ActionResult EliminarProducto(int id)
        {
            ObtenerProductoPorIdAD obtenerProductoPorIdAD = new ObtenerProductoPorIdAD();
            ProductosDTO producto = obtenerProductoPorIdAD.Obtener(id);

            if (producto == null)
            {
                return RedirectToAction("ListaDeProductos");
            }

            CompletarNombresDelProducto(producto);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarProducto(ProductosDTO elProductoParaGuardar)
        {
            try
            {
                await _eliminarProductoLN.Eliminar(elProductoParaGuardar);
                return RedirectToAction("ListaDeProductos");
            }
            catch
            {
                ObtenerProductoPorIdAD obtenerProductoPorIdAD = new ObtenerProductoPorIdAD();
                ProductosDTO producto = obtenerProductoPorIdAD.Obtener(elProductoParaGuardar.id);

                if (producto == null)
                {
                    return RedirectToAction("ListaDeProductos");
                }

                CompletarNombresDelProducto(producto);
                return View(producto);
            }
        }
    }
}
