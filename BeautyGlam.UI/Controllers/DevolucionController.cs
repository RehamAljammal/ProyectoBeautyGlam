using BeautyGlam.Abstracciones.AccesoADatos.Devolucion;
using BeautyGlam.Abstracciones.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.Abstracciones.LogicaNegocio;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Devolucion;
using BeautyGlam.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.AccesoADatos.Usuario.ListaUsuario;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class DevolucionController : Controller
    {
        private readonly IRegistrarDevolucionLN _ln;
        private readonly IObtenerListaDeProductosAD _productosAD;
        private readonly IListaDevolucionLN _listaLN;

        public DevolucionController()
        {
            var contexto = new Contexto();

            IRegistrarDevolucionAD ad = new RegistrarDevolucionAD(contexto);
            _ln = new RegistrarDevolucionLN(ad);

            _productosAD = new ObtenerLaListaDeProductosAD();

            IListaDevolucionAD listaAD = new ListaDevolucionAD(contexto);
            _listaLN = new ListaDevolucionLN(listaAD);
        }

        // LISTADO
        public ActionResult Listado()
        {
            var devoluciones = _listaLN.Obtener();
            return View(devoluciones);
        }

        // DETALLE
        public ActionResult Detalle(int id)
        {
            var devolucion = _listaLN.Obtener()
                                     .FirstOrDefault(x => x.id_Devolucion == id);

            if (devolucion == null)
            {
                return RedirectToAction("Listado");
            }

            return View(devolucion);
        }

        // GET REGISTRAR
        public ActionResult Registrar()
        {
            CargarClientes();
            return View(new DevolucionDto());
        }

        // POST REGISTRAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrar(DevolucionDto modelo)
        {
            if (!ModelState.IsValid)
            {
                CargarClientes();
                return View(modelo);
            }

            try
            {
                modelo.id_Admin = 1;

                await _ln.Registrar(modelo);

                TempData["Mensaje"] = "Devolución registrada correctamente";

                return RedirectToAction("Listado");
            }
            catch (Exception ex)
            {
                var error = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;

                ModelState.AddModelError("", error);

                CargarClientes();
                return View(modelo);
            }
        }

        // CARGAR CLIENTES
        private void CargarClientes()
        {
            var usuarios = new ObtenerListaDeUsuariosAD().Obtener()
                .Where(u => u.estado == true && u.rol == "Usuario")
                .Select(u => new
                {
                    id_Usuario = u.id_Usuario,
                    nombreCompleto = u.nombre + " " + u.apellido + " - " + u.correo
                })
                .ToList();

            ViewBag.Clientes = new SelectList(usuarios, "id_Usuario", "nombreCompleto");
        }

       

        public JsonResult ObtenerVentasPorCliente(int id_Usuario)
        {
            var ventas = _ln.ObtenerPorCliente(id_Usuario);

            return Json(ventas, JsonRequestBehavior.AllowGet);
        }
    }
}