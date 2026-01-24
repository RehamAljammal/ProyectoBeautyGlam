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
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            ProveedoresDto Proveedor = obtenerProveedorPorIdAD.Obtener(id);

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
            ProveedoresDto Proveedor = obtenerProveedorPorIdAD.Obtener(id);

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
                int cantidadDeFilasAfectadas = await _editarProveedorLN.Editar(elProveedorParaGuardar);

                return RedirectToAction("ListaDeProveedores");
            }
            catch
            {
                return View();
            }
        }

    
    
        // GET: Proveedor/Delete/5
        public ActionResult EliminarProveedor(int id)
        {
            ObtenerProveedorPorIdAD obtenerProveedorPorIdAD = new ObtenerProveedorPorIdAD();
            ProveedoresDto Proveedor = obtenerProveedorPorIdAD.Obtener(id);

            if (Proveedor == null)
            {
                return RedirectToAction("ListaDeProveedores");
            }

            return View(Proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminaProveedor(ProveedoresDto elProveedorParaGuardar)
        {
            try
            {
                int cantidadDeFilasAfectadas = await _eliminarProveedorLN.Eliminar(elProveedorParaGuardar);
                return RedirectToAction("ListaDeProveedores");
            }
            catch
            {
                return View(elProveedorParaGuardar);
            }
        }

    }
}

