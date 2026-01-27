using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.DetallesProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EditarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ListaProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.RegistrarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.ObtenerProductoPorId;
using BeautyGlam.LogicaDeNegocio.Categorias.ListaDeCategoria;
using BeautyGlam.LogicaDeNegocio.Marca.ListaDeMarca;
using BeautyGlam.LogicaDeNegocio.Productos.DetallesDeProducto;
using BeautyGlam.LogicaDeNegocio.Productos.EditarProductos;
using BeautyGlam.LogicaDeNegocio.Productos.EliminarProducto;
using BeautyGlam.LogicaDeNegocio.Productos.ListaProductos;
using BeautyGlam.LogicaDeNegocio.Productos.RegistrarProducto;
using BeautyGlam.LogicaDeNegocio.Proveedores.ListaDeProveedor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
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
            ViewBag.Categorias = new SelectList(
                _obtenerLaListaDeCategoriasLN.Obtener(),
                "id",
                "nombre",
                model?.idCategoria
            );

            ViewBag.Marcas = new SelectList(
                _obtenerListaDeMarcaLN.Obtener(),
                "id_Marca",
                "nombre",
                model?.idMarca
            );

            ViewBag.Proveedores = new SelectList(
                _obtenerLaListaDeProveedoresLN.Obtener(),
                "id",
                "nombre",
                model?.idProveedor
            );
        }

        public ActionResult ListaDeProductos()
        {
            return View(_obtenerLaListaDeProductosLN.Obtener());
        }

        public ActionResult DetallesDelProducto(int id)
        {
            ProductosDTO producto = new ObtenerProductoPorIdAD().Obtener(id);
            if (producto == null) return RedirectToAction("ListaDeProductos");
            return View(producto);
        }

        public ActionResult CrearProducto()
        {
            CargarCombos();
            return View();
        }

        // ================== CREAR PRODUCTO ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearProducto(ProductosDTO elProductoParaGuardar, HttpPostedFileBase imagen)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarCombos(elProductoParaGuardar);
                    return View(elProductoParaGuardar);
                }

                // ---- Guardar imagen ----
                if (imagen != null && imagen.ContentLength > 0)
                {
                    string carpeta = Server.MapPath("~/img/productos/");
                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    string nombreArchivo = Guid.NewGuid() + Path.GetExtension(imagen.FileName);
                    imagen.SaveAs(Path.Combine(carpeta, nombreArchivo));

                    elProductoParaGuardar.imagen = "/img/productos/" + nombreArchivo;
                }
                else
                {
                    elProductoParaGuardar.imagen = "/img/productos/default.png";
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
            ProductosDTO producto = new ObtenerProductoPorIdAD().Obtener(id);
            if (producto == null) return RedirectToAction("ListaDeProductos");

            CargarCombos(producto);
            return View(producto);
        }

        // ================== EDITAR PRODUCTO ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarProducto(ProductosDTO elProductoParaGuardar, HttpPostedFileBase imagen)
        {
            try
            {
                ProductosDTO productoActual = await _editarProductoLN.ObtenerPorId(elProductoParaGuardar.id);
                if (productoActual == null) return RedirectToAction("ListaDeProductos");

                productoActual.nombre = elProductoParaGuardar.nombre;
                productoActual.descripcion = elProductoParaGuardar.descripcion;
                productoActual.precio = elProductoParaGuardar.precio;
                productoActual.idCategoria = elProductoParaGuardar.idCategoria;
                productoActual.idMarca = elProductoParaGuardar.idMarca;
                productoActual.idProveedor = elProductoParaGuardar.idProveedor;
                productoActual.estado = elProductoParaGuardar.estado;

                // ---- Nueva imagen (opcional) ----
                if (imagen != null && imagen.ContentLength > 0)
                {
                    string carpeta = Server.MapPath("~/img/productos/");
                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    string nombreArchivo = Guid.NewGuid() + Path.GetExtension(imagen.FileName);
                    imagen.SaveAs(Path.Combine(carpeta, nombreArchivo));

                    productoActual.imagen = "/img/productos/" + nombreArchivo;
                }

                await _editarProductoLN.Editar(productoActual);
                return RedirectToAction("ListaDeProductos");
            }
            catch
            {
                CargarCombos(elProductoParaGuardar);
                return View(elProductoParaGuardar);
            }
        }

        public ActionResult EliminarProducto(int id)
        {
            ProductosDTO producto = new ObtenerProductoPorIdAD().Obtener(id);
            if (producto == null) return RedirectToAction("ListaDeProductos");
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarProducto(ProductosDTO elProductoParaGuardar)
        {
            await _eliminarProductoLN.Eliminar(elProductoParaGuardar);
            return RedirectToAction("ListaDeProductos");
        }
    }
}