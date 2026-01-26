using BeautyGlam.Abstracciones.AccesoADatos.Marca.ListaDeMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.DetallesDeMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EditarMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EliminarMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.RegistrarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marcaes.ObtenerMarcaPorID;
using BeautyGlam.LogicaDeNegocio.Marca.DetallesMarca;
using BeautyGlam.LogicaDeNegocio.Marca.EditarMarca;
using BeautyGlam.LogicaDeNegocio.Marca.EliminarMarca;
using BeautyGlam.LogicaDeNegocio.Marcaes.ListaDeMarca;
using BeautyGlam.LogicaDeNegocio.Marcaes.RegistrarMarca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class MarcaController : Controller
    {

        private readonly IObtenerListaDeMarcaAD _obtenerLaListaDeMarcasLN;
        private readonly IRegistrarMarcaLN _agregarMarcaLN;
        private readonly IEditarMarcaLN _editarMarcaLN;
        private readonly IEliminarMarcaLN _eliminarMarcaLN;
        private readonly IDetallesMarcaLN _detallesMarcaLN;

        public MarcaController()
        {
            _obtenerLaListaDeMarcasLN = new ObtenerListaDeMarcaLN();
            _agregarMarcaLN = new RegistrarMarcaLN();
            _editarMarcaLN = new EditarMarcaLN();
            _eliminarMarcaLN = new EliminarMarcaLN();
            _detallesMarcaLN = new DetallesMarcaLN();


        }


        // Listar Marca
        public ActionResult ListaDeMarcas()
        {
            List<MarcaDto> laListaDeMarcas = _obtenerLaListaDeMarcasLN.Obtener();
            return View(laListaDeMarcas);
        }

        // Ver detalles de la Marca
        public ActionResult DetallesDelMarca(int id)
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




        // GET: Marca/Delete/5
        public ActionResult EliminarMarca(int id)
        {
            ObtenerMarcaPorIdAD obtenerMarcaPorIdAD = new ObtenerMarcaPorIdAD();
            MarcaDto Marca = obtenerMarcaPorIdAD.ObtenerPorId(id);

            if (Marca == null)
            {
                return RedirectToAction("ListaDeMarcas");
            }

            return View(Marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarMarca(MarcaDto elMarcaParaGuardar)
        {
            try
            {
                await _eliminarMarcaLN.Eliminar(elMarcaParaGuardar);
                return RedirectToAction("ListaDeMarcas");
            }
            catch
            {
                return View(elMarcaParaGuardar);
            }
        }


    }
}

