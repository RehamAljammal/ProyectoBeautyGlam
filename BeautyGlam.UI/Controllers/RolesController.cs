using BeautyGlam.Abstracciones.AccesoADatos.Rol.ListaRol;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EditarRol;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EliminarRol;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.RegistrarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Rol.ListaRol;
using BeautyGlam.AccesoADatos.Rol.ObtenerRolPorId;
using BeautyGlam.LogicaDeNegocio.Rol.EditarRol;
using BeautyGlam.LogicaDeNegocio.Rol.EliminarRol;
using BeautyGlam.LogicaDeNegocio.Rol.RegistrarRol;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolController : Controller
    {
        private readonly IObtenerListaDeRolesAD _obtenerLaListaDeRolesLN;
        private readonly IRegistrarRolLN _agregarRolLN;
        private readonly IEditarRolLN _editarRolLN;
        private readonly IEliminarRolLN _eliminarRolLN;

        public RolController()
        {
            _obtenerLaListaDeRolesLN = new ObtenerListaDeRolesAD();
            _agregarRolLN = new RegistrarRolLN();
            _editarRolLN = new EditarRolLN();
            _eliminarRolLN = new EliminarRolLN();
        }

        // Listar Roles
        public ActionResult ListaDeRoles()
        {
            List<RolDto> laListaDeRoles = _obtenerLaListaDeRolesLN.Obtener();
            return View(laListaDeRoles);
        }

        // Ver detalles del Rol
        public ActionResult DetallesRol(int id)
        {
            ObtenerRolPorIdAD obtenerRolPorIdAD = new ObtenerRolPorIdAD();
            RolDto elRol = obtenerRolPorIdAD.ObtenerPorId(id);

            if (elRol == null)
            {
                return RedirectToAction("ListaDeRoles");
            }

            return View(elRol);
        }

        // GET: Rol/CrearRol
        public ActionResult CrearRol()
        {
            return View();
        }

        // POST: Rol/CrearRol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearRol(RolDto elRolParaGuardar)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(elRolParaGuardar);
                }

                int cantidadDeFilasAfectadas = await _agregarRolLN.Registrar(elRolParaGuardar);

                return RedirectToAction("ListaDeRoles");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear: " + ex.Message);
                return View(elRolParaGuardar);
            }
        }

        // GET: Rol/EditarRol/5
        public ActionResult EditarRol(int id)
        {
            ObtenerRolPorIdAD obtenerRolPorIdAD = new ObtenerRolPorIdAD();
            RolDto elRol = obtenerRolPorIdAD.ObtenerPorId(id);

            if (elRol == null)
            {
                return RedirectToAction("ListaDeRoles");
            }

            return View(elRol);
        }

        // POST: Rol/EditarRol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarRol(RolDto elRolParaGuardar)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(elRolParaGuardar);
                }

                RolDto rolActual = await _editarRolLN.ObtenerPorId(elRolParaGuardar.id_Rol);

                if (rolActual == null)
                {
                    ModelState.AddModelError("", "No existe el rol.");
                    return View(elRolParaGuardar);
                }

                rolActual.nombre_Rol = elRolParaGuardar.nombre_Rol;
                rolActual.estado = elRolParaGuardar.estado;

                await _editarRolLN.Editar(rolActual);

                return RedirectToAction("ListaDeRoles");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(elRolParaGuardar);
            }
        }

        // GET: Rol/EliminarRol/5
        public ActionResult EliminarRol(int id)
        {
            ObtenerRolPorIdAD obtenerRolPorIdAD = new ObtenerRolPorIdAD();
            RolDto elRol = obtenerRolPorIdAD.ObtenerPorId(id);

            if (elRol == null)
            {
                return RedirectToAction("ListaDeRoles");
            }

            return View(elRol);
        }

        // POST: Rol/EliminarRol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarRol(RolDto elRolParaGuardar)
        {
            try
            {
                await _eliminarRolLN.Eliminar(elRolParaGuardar);
                return RedirectToAction("ListaDeRoles");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar: " + ex.Message);
                return View(elRolParaGuardar);
            }
        }
    }
}
