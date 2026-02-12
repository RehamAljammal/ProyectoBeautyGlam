using BeautyGlam.Abstracciones.AccesoADatos.Categoria.ListaCategoria;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.DetallesCategoria;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EditarCategoria;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EliminarCategoria;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.RegistrarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.ObtenerCategoriaPorID;
using BeautyGlam.LogicaDeNegocio.Categorias.DetallesDeCategoria;
using BeautyGlam.LogicaDeNegocio.Categorias.EditarCategorias;
using BeautyGlam.LogicaDeNegocio.Categorias.EliminarCategoria;
using BeautyGlam.LogicaDeNegocio.Categorias.ListaDeCategoria;
using BeautyGlam.LogicaDeNegocio.Categorias.RegistrarCategoria;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly IObtenerListaDeCategoriasAD _obtenerLaListaDeCategoriasLN;
        private readonly IRegistrarCategoriaLN _agregarCategoriaLN;
        private readonly IEditarCategoriaLN _editarCategoriaLN;
        private readonly IEliminarCategoriaLN _eliminarCategoriaLN;
        private readonly IDetallesCategoriaLN _detallesCategoriaLN;
        public CategoriasController()
        {
            _obtenerLaListaDeCategoriasLN = new ObtenerLaListaDeCategoriasLN();
            _agregarCategoriaLN = new RegistrarCategoriaLN();
            _editarCategoriaLN = new EditarCategoriaLN();
            _eliminarCategoriaLN = new EliminarCategoriaLN();
            _detallesCategoriaLN = new DetallesCategoriaLN();


        }

        // GET: Categorias
        public ActionResult ListaDeCategorias()
        {
            List<CategoriasDto> laListaDeCategorias = _obtenerLaListaDeCategoriasLN.Obtener();
            return View(laListaDeCategorias);
        }

        // GET: Categorias/Details/5
        public ActionResult DetalleCategoria(int id)
        {
            ObtenerCategoriaPorIdAD obtenerCategoriaPorIdAD = new ObtenerCategoriaPorIdAD();
            CategoriasDto Categoria = obtenerCategoriaPorIdAD.ObtenerPorId(id);

            if (Categoria == null)
            {
                return RedirectToAction("ListaDeCategorias");
            }

            return View(Categoria);
        }

        // GET: Categorias/Create
        public ActionResult CrearCategoria()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public async Task<ActionResult> CrearCategoria(CategoriasDto laCategoriaParaGuardar)
        {
            try
            {
                // TODO: Add insert logic here
                int cantidadDeFilasAfectadas = await _agregarCategoriaLN.Registrar(laCategoriaParaGuardar);

                return RedirectToAction("ListaDeCategorias");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/EditarCategoria/5
        public ActionResult EditarCategoria(int id)
        {
            ObtenerCategoriaPorIdAD obtenerCategoriaPorIdAD = new ObtenerCategoriaPorIdAD();
            CategoriasDto Categoria = obtenerCategoriaPorIdAD.ObtenerPorId(id);

            if (Categoria == null)
            {
                return RedirectToAction("ListaDeCategorias");
            }

            return View(Categoria);
        }


        // POST: Categoria/EditarCategoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarCategoria(CategoriasDto laCategoriaParaGuardar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(laCategoriaParaGuardar);

                CategoriasDto CategoriaActual =
                    await _editarCategoriaLN.ObtenerPorId(laCategoriaParaGuardar.id);

                if (CategoriaActual == null)
                {
                    ModelState.AddModelError("", "No existe la Categoria.");
                    return View(laCategoriaParaGuardar);
                }

                CategoriaActual.nombre = laCategoriaParaGuardar.nombre;
                CategoriaActual.descripcion = laCategoriaParaGuardar.descripcion;
                CategoriaActual.estado = laCategoriaParaGuardar.estado;


                await _editarCategoriaLN.Editar(CategoriaActual);

                return RedirectToAction("ListaDeCategorias"); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(laCategoriaParaGuardar);
            }
        }




        // GET: Categoria/Delete/5
        public ActionResult EliminarCategoria(int id)
        {
            ObtenerCategoriaPorIdAD obtenerCategoriaPorIdAD = new ObtenerCategoriaPorIdAD();
            CategoriasDto Categoria = obtenerCategoriaPorIdAD.ObtenerPorId(id);

            if (Categoria == null)
            {
                return RedirectToAction("ListaDeCategorias");
            }

            return View(Categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarCategoria(CategoriasDto laCategoriaParaGuardar)
        {
            try
            {
                await _eliminarCategoriaLN.Eliminar(laCategoriaParaGuardar);
                return RedirectToAction("ListaDeCategorias");
            }
            catch
            {
                return View(laCategoriaParaGuardar);
            }
        }
    }
}


