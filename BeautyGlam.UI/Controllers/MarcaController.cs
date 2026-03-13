using BeautyGlam.Abstracciones.AccesoADatos.Marca.ListaDeMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.DetallesDeMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EditarMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EliminarMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.RegistrarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marcaes.ObtenerMarcaPorID;
using BeautyGlam.LogicaDeNegocio.Marca.ActivarDesactivar;
using BeautyGlam.LogicaDeNegocio.Marca.DetallesMarca;
using BeautyGlam.LogicaDeNegocio.Marca.EditarMarca;
using BeautyGlam.LogicaDeNegocio.Marca.ListaDeMarca;
using BeautyGlam.LogicaDeNegocio.Marca.RegistrarMarca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{

    public class MarcaController : Controller
    {

        private readonly IObtenerListaDeMarcaAD _obtenerLaListaDeMarcasLN;
        private readonly IRegistrarMarcaLN _agregarMarcaLN;
        private readonly IEditarMarcaLN _editarMarcaLN;
        private readonly IDetallesMarcaLN _detallesMarcaLN;
        private readonly IActivarDesactivarMarcaLN _activarDesactivarMarcaLN;

        public MarcaController()
        {
            _obtenerLaListaDeMarcasLN = new ObtenerListaDeMarcaLN();
            _agregarMarcaLN = new RegistrarMarcaLN();
            _editarMarcaLN = new EditarMarcaLN();
            _detallesMarcaLN = new DetallesMarcaLN();
            _activarDesactivarMarcaLN = new ActivarDesactivarMarcaLN();

        }


        // Listar Marca
        public ActionResult ListaDeMarcas(string buscar, int pagina = 1)
        {
            int registrosPorPagina = 10;

            List<MarcaDto> lista = _obtenerLaListaDeMarcasLN.Obtener();

            // BUSCADOR
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                buscar = buscar.ToLower().Trim();

                lista = lista.Where(m =>
                    (m.nombre ?? "").ToLower().Contains(buscar)
                ).ToList();
            }

            // ORDENAR POR MÁS NUEVO
            lista = lista
                .OrderByDescending(x => x.estado)
                .OrderByDescending(x => x.id_Marca).ToList();

            int totalRegistros = lista.Count();

            var marcasPaginadas = lista
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);
            ViewBag.Buscar = buscar;

            return View(marcasPaginadas);
        }

        // Ver detalles de la Marca
        public ActionResult DetallesMarca(int id)
        {
            ObtenerMarcaPorIdAD obtenerMarcaPorIdAD = new ObtenerMarcaPorIdAD();
            MarcaDto Marca = obtenerMarcaPorIdAD.ObtenerPorId(id);

            if (Marca == null)
            {
                return RedirectToAction("ListaDeMarcas");
            }

            return View(Marca);
        }

        // GET: Marca/Create
        public ActionResult CrearMarca()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public async Task<ActionResult> CrearMarca(MarcaDto elMarcaParaGuardar)
        {
            try
            {
                // TODO: Add insert logic here
                int cantidadDeFilasAfectadas = await _agregarMarcaLN.Registrar(elMarcaParaGuardar);

                return RedirectToAction("ListaDeMarcas");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/EditarMarca/5
        public ActionResult EditarMarca(int id)
        {
            ObtenerMarcaPorIdAD obtenerMarcaPorIdAD = new ObtenerMarcaPorIdAD();
            MarcaDto Marca = obtenerMarcaPorIdAD.ObtenerPorId(id);

            if (Marca == null)
            {
                return RedirectToAction("ListaDeMarcas");
            }

            return View(Marca);
        }


        // POST: Marca/EditarMarca
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarMarca(MarcaDto elMarcaParaGuardar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(elMarcaParaGuardar);

                MarcaDto MarcaActual =
                    await _editarMarcaLN.ObtenerPorId(elMarcaParaGuardar.id_Marca);

                if (MarcaActual == null)
                {
                    ModelState.AddModelError("", "No existe la Marca.");
                    return View(elMarcaParaGuardar);
                }

                MarcaActual.nombre = elMarcaParaGuardar.nombre;
                MarcaActual.estado = elMarcaParaGuardar.estado;


                await _editarMarcaLN.Editar(MarcaActual);

                return RedirectToAction("ListaDeMarcas"); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(elMarcaParaGuardar);
            }
        }


        public async Task<ActionResult> ActivarDesactivarMarca(int id)
        {
            var marca = _obtenerLaListaDeMarcasLN.Obtener()
                            .FirstOrDefault(x => x.id_Marca == id);

            if (marca == null)
            {
                return RedirectToAction("ListaDeMarcas");
            }

            await _activarDesactivarMarcaLN.ActivarDesactivar(marca);

            return RedirectToAction("ListaDeMarcas");
        }
    }
}

