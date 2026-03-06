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
using BeautyGlam.LogicaDeNegocio.Tono;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly ObtenerListaTonoLN _obtenerListaTonoLN;
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
            _obtenerListaTonoLN = new ObtenerListaTonoLN();
        }

        // ===== Cargar combos para dropdowns =====
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

            ViewBag.Tonos = new SelectList(
           _obtenerListaTonoLN.ObtenerTodos(),
           "id_Tono",
           "nombre",
           model?.id_Tono
   );
        }

        // ================== LISTA DE PRODUCTOS CON FILTROS ==================
        public ActionResult ListaDeProductos(
            int? idCategoria,
            int? id_Tono,
            string tipoPiel,
            int? idMarca,
            decimal? precioMin,
            decimal? precioMax
        )
        {
            var productos = _obtenerLaListaDeProductosLN.Obtener()
                             .Where(p => p.estado)
                             .ToList();

            // Aplicar filtros
            if (idCategoria.HasValue)
                productos = productos.Where(p => p.idCategoria == idCategoria.Value).ToList();

            if (id_Tono.HasValue)
                productos = productos.Where(p => p.id_Tono == id_Tono.Value).ToList();

            if (!string.IsNullOrEmpty(tipoPiel))
                productos = productos.Where(p => p.tipoPiel == tipoPiel).ToList();

            if (idMarca.HasValue)
                productos = productos.Where(p => p.idMarca == idMarca.Value).ToList();

            if (precioMin.HasValue)
                productos = productos.Where(p => p.precio >= precioMin.Value).ToList();

            if (precioMax.HasValue)
                productos = productos.Where(p => p.precio <= precioMax.Value).ToList();

            if (!productos.Any())
                ViewBag.Mensaje = "No se encontraron productos que coincidan con los filtros";

            // Cargar combos para filtros
            CargarCombos();

            // Mantener valores seleccionados
            ViewBag.idCategoria = idCategoria;
            ViewBag.id_Tono = id_Tono;
            ViewBag.tipoPiel = tipoPiel;
            ViewBag.idMarca = idMarca;
            ViewBag.precioMin = precioMin;
            ViewBag.precioMax = precioMax;

            return View(productos);
        }

        // Acción AJAX para actualización dinámica de la tabla
        public ActionResult FiltrarProductos(
            int? idCategoria,
            int? id_Tono,
            string tipoPiel,
            int? idMarca,
            decimal? precioMin,
            decimal? precioMax
        )
        {
            var productos = _obtenerLaListaDeProductosLN.Obtener()
                             .Where(p => p.estado)
                             .ToList();

            if (idCategoria.HasValue)
                productos = productos.Where(p => p.idCategoria == idCategoria.Value).ToList();


            if (id_Tono.HasValue)
                productos = productos.Where(p => p.id_Tono == id_Tono.Value).ToList();

            if (!string.IsNullOrEmpty(tipoPiel))
                productos = productos.Where(p => p.tipoPiel == tipoPiel).ToList();

            if (idMarca.HasValue)
                productos = productos.Where(p => p.idMarca == idMarca.Value).ToList();

            if (precioMin.HasValue)
                productos = productos.Where(p => p.precio >= precioMin.Value).ToList();

            if (precioMax.HasValue)
                productos = productos.Where(p => p.precio <= precioMax.Value).ToList();

            return PartialView("_TablaProductos", productos);
        }

        // ================== DETALLES DEL PRODUCTO ==================
        public ActionResult DetallesDelProducto(int id)
        {
            ProductosDTO producto = new ObtenerProductoPorIdAD().Obtener(id);
            if (producto == null) return RedirectToAction("ListaDeProductos");
            return View(producto);
        }

        // ================== CREAR PRODUCTO ==================
        public ActionResult CrearProducto()
        {
            CargarCombos();
            return View();
        }

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

                elProductoParaGuardar.estado = true;

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
        // ================== EDITAR PRODUCTO ==================
        public ActionResult EditarProducto(int id)
        {
            ProductosDTO producto = new ObtenerProductoPorIdAD().Obtener(id);
            if (producto == null) return RedirectToAction("ListaDeProductos");

            CargarCombos(producto);
            return View(producto);
        }

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
                productoActual.id_Tono = elProductoParaGuardar.id_Tono;
                productoActual.tipoPiel = elProductoParaGuardar.tipoPiel;
                productoActual.estado = elProductoParaGuardar.estado;

                // Imagen opcional
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

        // ================== ELIMINAR PRODUCTO ==================
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