using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Ocasiones;
using BeautyGlam.LogicaDeNegocio.Ocasiones.ActivarDesactivar;
using BeautyGlam.LogicaDeNegocio.Ocasiones.Editar;
using BeautyGlam.LogicaDeNegocio.Ocasiones.Lista;
using BeautyGlam.LogicaDeNegocio.Ocasiones.Registrar;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class OcasionesController : Controller
    {
        private readonly ObtenerOcasionesLN _obtenerLN;
        private readonly RegistrarOcasionLN _registrarLN;
        private readonly EditarOcasionLN _editarLN;
        private readonly ActivarDesactivarOcasionLN _eliminarLN;

        public OcasionesController()
        {
            _obtenerLN = new ObtenerOcasionesLN();
            _registrarLN = new RegistrarOcasionLN();
            _editarLN = new EditarOcasionLN();
            _eliminarLN = new ActivarDesactivarOcasionLN();
        }

        public ActionResult ListaOcasiones(string buscar, int pagina = 1)
        {
            int registrosPorPagina = 10;

            // Obtener lista de ocasiones
            var lista = _obtenerLN.Obtener();

            // FILTRO DE BÚSQUEDA
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                buscar = buscar.ToLower().Trim();
                lista = lista.Where(o => o.nombre.ToLower().Contains(buscar)).ToList();
            }

            // ORDENAR POR MÁS NUEVO, activas primero
            lista = lista.OrderByDescending(o => o.estado) // Primero las activas
                         .ThenByDescending(o => o.idOcasion) // Luego por fecha
                         .ToList();

            // Cálculo de total de registros para la paginación
            int totalRegistros = lista.Count();

            // Implementar paginación
            var ocasionesPaginadas = lista
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            // Establecer valores para la paginación
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);
            ViewBag.Buscar = buscar;

            return View(ocasionesPaginadas);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(OcasionDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _registrarLN.Registrar(dto);

            return RedirectToAction("ListaOcasiones");
        }

        public ActionResult Editar(int id)
        {
            var ocasion = _obtenerLN.Obtener()
                .FirstOrDefault(x => x.idOcasion == id);

            return View(ocasion);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(OcasionDto dto)
        {
            await _editarLN.Editar(dto);

            return RedirectToAction("ListaOcasiones");
        }

        public async Task<ActionResult> ActivarDesactivar(int id)
        {
            var ocasion = _obtenerLN.Obtener()
                                    .FirstOrDefault(x => x.idOcasion == id);

            if (ocasion == null)
            {
                return RedirectToAction("ListaOcasiones");
            }

            // Cambiar el estado de la ocasión (activar/desactivar)
            ocasion.estado = !ocasion.estado; // Si está activa, la desactiva; si está inactiva, la activa

            // Guardar los cambios de forma asincrónica
            await _editarLN.Editar(ocasion);

            return RedirectToAction("ListaOcasiones");
        }
    }
}