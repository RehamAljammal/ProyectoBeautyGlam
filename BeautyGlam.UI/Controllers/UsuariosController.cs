using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.CambiarEstadoUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.EditarUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.RegistrarUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.ListaRol;
using BeautyGlam.Abstracciones.ModelosParaUI;

using BeautyGlam.LogicaDeNegocio.Usuario.CambiarEstadoUsuario;
using BeautyGlam.LogicaDeNegocio.Usuario.EditarUsuario;
using BeautyGlam.LogicaDeNegocio.Usuario.ListaUsuario;
using BeautyGlam.LogicaDeNegocio.Usuario.RegistrarUsuario;
using BeautyGlam.LogicaDeNegocio.Rol.ListaRol;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly IObtenerLaListaDeUsuariosLN _obtenerLaListaDeUsuariosLN;
        private readonly IRegistrarUsuarioLN _registrarUsuarioLN;
        private readonly IEditarUsuarioLN _editarUsuarioLN;
        private readonly IActualizarEstadoUsuarioLN _estadoUsuarioLN;

        private readonly IObtenerLaListaDeRolesLN _rolesLN;

        public UsuariosController()
        {
            _obtenerLaListaDeUsuariosLN = new ObtenerLaListaDeUsuariosLN();
            _registrarUsuarioLN = new RegistrarUsuarioLN();
            _editarUsuarioLN = new EditarUsuarioLN();
            _estadoUsuarioLN = new ActualizarEstadoUsuarioLN();

            _rolesLN = new ObtenerLaListaDeRolesLN();
        }

        // =========================
        // Helpers
        // =========================
        private void CargarRoles(string rolSeleccionado)
        {
            List<RolDto> roles = _rolesLN.Obtener();

            // Solo roles activos
            List<RolDto> rolesActivos = roles
                .Where(r => r.estado == true)
                .OrderBy(r => r.nombre_Rol)
                .ToList();

            ViewBag.Roles = new SelectList(
                rolesActivos,
                "nombre_Rol",   // Value (se guarda en Usuario.rol)
                "nombre_Rol",   // Text
                rolSeleccionado
            );
        }

        // =========================
        // LISTA
        // =========================
        public ActionResult ListaDeUsuarios()
        {
            List<UsuarioDto> lista = _obtenerLaListaDeUsuariosLN.Obtener();
            return View(lista);
        }

        // =========================
        // CREAR (GET)
        // =========================
        public ActionResult CrearUsuario()
        {
            UsuarioCrearDto model = new UsuarioCrearDto();
            model.estado = true;
            model.rol = "Usuario";

            CargarRoles(model.rol);
            return View(model);
        }

        // =========================
        // CREAR (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearUsuario(UsuarioCrearDto elUsuarioParaGuardar)
        {
            try
            {
                // IMPORTANTE: recargar roles SIEMPRE antes de retornar la vista
                CargarRoles(elUsuarioParaGuardar.rol);

                if (ModelState.IsValid == false)
                {
                    return View(elUsuarioParaGuardar);
                }

                int filas = await _registrarUsuarioLN.Registrar(elUsuarioParaGuardar);

                if (filas <= 0)
                {
                    ModelState.AddModelError("", "No se pudo registrar el usuario.");
                    return View(elUsuarioParaGuardar);
                }

                return RedirectToAction("ListaDeUsuarios");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear: " + ex.Message);
                CargarRoles(elUsuarioParaGuardar.rol);
                return View(elUsuarioParaGuardar);
            }
        }

        // =========================
        // EDITAR (GET)
        // =========================
        public async Task<ActionResult> EditarUsuario(int id)
        {
            UsuarioDto usuario = await _editarUsuarioLN.ObtenerPorId(id);

            if (usuario == null)
            {
                return RedirectToAction("ListaDeUsuarios");
            }

            // combo roles
            CargarRoles(usuario.rol);

            return View(usuario);
        }

        // =========================
        // EDITAR (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarUsuario(UsuarioDto elUsuarioParaGuardar)
        {
            try
            {
                CargarRoles(elUsuarioParaGuardar.rol);

                if (ModelState.IsValid == false)
                {
                    return View(elUsuarioParaGuardar);
                }

                UsuarioDto usuarioActual = await _editarUsuarioLN.ObtenerPorId(elUsuarioParaGuardar.id_Usuario);

                if (usuarioActual == null)
                {
                    ModelState.AddModelError("", "No existe el usuario.");
                    return View(elUsuarioParaGuardar);
                }

                usuarioActual.nombre = elUsuarioParaGuardar.nombre;
                usuarioActual.apellido = elUsuarioParaGuardar.apellido;
                usuarioActual.username = elUsuarioParaGuardar.username;
                usuarioActual.correo = elUsuarioParaGuardar.correo;
                usuarioActual.telefono = elUsuarioParaGuardar.telefono;
                usuarioActual.direccion = elUsuarioParaGuardar.direccion;
                usuarioActual.rol = elUsuarioParaGuardar.rol;
                usuarioActual.estado = elUsuarioParaGuardar.estado;

                int filas = await _editarUsuarioLN.Editar(usuarioActual);

                if (filas <= 0)
                {
                    ModelState.AddModelError("", "No se pudo editar el usuario.");
                    return View(elUsuarioParaGuardar);
                }

                return RedirectToAction("ListaDeUsuarios");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                CargarRoles(elUsuarioParaGuardar.rol);
                return View(elUsuarioParaGuardar);
            }
        }

        // =========================
        // CAMBIAR ESTADO (GET confirmación)
        // =========================
        public async Task<ActionResult> CambiarEstado(int id)
        {
            UsuarioDto usuario = await _editarUsuarioLN.ObtenerPorId(id);

            if (usuario == null)
            {
                return RedirectToAction("ListaDeUsuarios");
            }

            return View(usuario);
        }

        // =========================
        // CAMBIAR ESTADO (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CambiarEstado(int id, bool nuevoEstado)
        {
            try
            {
                int filas = await _estadoUsuarioLN.ActualizarEstado(id, nuevoEstado);

                if (filas <= 0)
                {
                    ModelState.AddModelError("", "No se pudo actualizar el estado.");
                }

                return RedirectToAction("ListaDeUsuarios");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al cambiar estado: " + ex.Message);
                return RedirectToAction("ListaDeUsuarios");
            }
        }
    }
}
