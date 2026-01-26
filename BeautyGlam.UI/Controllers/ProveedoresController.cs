using BeautyGlam.Abstracciones.AccesoADatos.Proveedores.ListaDeProveedor;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.DetallesDeProveedor;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.EditarProveedores;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.EliminarProveedor;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.RegistrarProveedor;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Proveedores.ObtenerProveedorPorID;
using BeautyGlam.LogicaDeNegocio.Proveedores.DetallesDeProveedor;
using BeautyGlam.LogicaDeNegocio.Proveedores.EditarProveedores;
using BeautyGlam.LogicaDeNegocio.Proveedores.EliminarProveedor;
using BeautyGlam.LogicaDeNegocio.Proveedores.ListaDeProveedor;
using BeautyGlam.LogicaDeNegocio.Proveedores.RegistrarProveedor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
        public class ProveedoresController : Controller
        {

        private readonly IObtenerListaDeProveedoresAD _obtenerLaListaDeProveedoresLN;
        private readonly IRegistrarProveedorLN _agregarProveedorLN;
        private readonly IEditarProveedorLN _editarProveedorLN;
        private readonly IEliminarProveedorLN _eliminarProveedorLN;
        private readonly IDetallesProveedorLN _detallesProveedorLN;

        public ProveedoresController()
        {
            _obtenerLaListaDeProveedoresLN = new ObtenerLaListaDeProveedoresLN();
            _agregarProveedorLN = new RegistrarProveedorLN();
            _editarProveedorLN = new EditarProveedorLN();
            _eliminarProveedorLN = new EliminarProveedorLN();
            _detallesProveedorLN = new DetallesProveedorLN();


        }


        // Listar proveedores
        public ActionResult ListaDeProveedores()
            {
            List<ProveedoresDto> laListaDeProveedores = _obtenerLaListaDeProveedoresLN.Obtener();
            return View(laListaDeProveedores);
        }

        // Ver detalles del proveedor
        public ActionResult DetallesDelProveedor(int id)
        {
            ObtenerProveedorPorIdAD obtenerProveedorPorIdAD = new ObtenerProveedorPorIdAD();
            ProveedoresDto Proveedor = obtenerProveedorPorIdAD.ObtenerPorId(id);

            if (Proveedor == null)
            {
                return RedirectToAction("ListaDeProveedores");
            }

            return View(Proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult CrearProveedor()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public async Task<ActionResult> CrearProveedor(ProveedoresDto elProveedorParaGuardar)
        {
            try
            {
                // TODO: Add insert logic here
                int cantidadDeFilasAfectadas = await _agregarProveedorLN.Registrar(elProveedorParaGuardar);

                return RedirectToAction("ListaDeProveedores");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proveedor/EditarProveedor/5
        public ActionResult EditarProveedor(int id)
        {
            ObtenerProveedorPorIdAD obtenerProveedorPorIdAD = new ObtenerProveedorPorIdAD();
            ProveedoresDto Proveedor = obtenerProveedorPorIdAD.ObtenerPorId(id);

            if (Proveedor == null)
            {
                return RedirectToAction("ListaDeProveedores");
            }

            return View(Proveedor);
        }


        // POST: Proveedor/EditarProveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarProveedor(ProveedoresDto elProveedorParaGuardar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(elProveedorParaGuardar);

                ProveedoresDto proveedorActual =
                    await _editarProveedorLN.ObtenerPorId(elProveedorParaGuardar.id);

                if (proveedorActual == null)
                {
                    ModelState.AddModelError("", "No existe el proveedor.");
                    return View(elProveedorParaGuardar);
                }

                proveedorActual.nombre = elProveedorParaGuardar.nombre;
                proveedorActual.telefono = elProveedorParaGuardar.telefono;
                proveedorActual.correo = elProveedorParaGuardar.correo;
                proveedorActual.direccion = elProveedorParaGuardar.direccion;
                proveedorActual.cedula = elProveedorParaGuardar.cedula;
                proveedorActual.estado = elProveedorParaGuardar.estado;


                await _editarProveedorLN.Editar(proveedorActual);

                return RedirectToAction("ListaDeProveedores"); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(elProveedorParaGuardar);
            }
        }




        // GET: Proveedor/Delete/5
        public ActionResult EliminarProveedor(int id)
        {
            ObtenerProveedorPorIdAD obtenerProveedorPorIdAD = new ObtenerProveedorPorIdAD();
            ProveedoresDto Proveedor = obtenerProveedorPorIdAD.ObtenerPorId(id);

            if (Proveedor == null)
            {
                return RedirectToAction("ListaDeProveedores");
            }

            return View(Proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarProveedor(ProveedoresDto elProveedorParaGuardar)
        {
            try
            {
                await _eliminarProveedorLN.Eliminar(elProveedorParaGuardar);
                return RedirectToAction("ListaDeProveedores");
            }
            catch
            {
                return View(elProveedorParaGuardar);
            }
        }


    }
}


