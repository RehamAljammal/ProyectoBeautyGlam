using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.ObtenerProductoPorId;
using BeautyGlam.LogicaDeNegocio.Catalogo;
using BeautyGlam.LogicaDeNegocio.Categorias.ListaDeCategoria;
using BeautyGlam.LogicaDeNegocio.Marca.ListaDeMarca;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ObtenerCatalogoLN _catalogoLN;
        private readonly ObtenerLaListaDeCategoriasLN _categoriasLN;
        private readonly ObtenerListaDeMarcaLN _marcasLN;

        public CatalogoController()
        {
            _catalogoLN = new ObtenerCatalogoLN();
            _categoriasLN = new ObtenerLaListaDeCategoriasLN();
            _marcasLN = new ObtenerListaDeMarcaLN();
        }

        private void CargarCombos(int? idCategoria, int? idMarca)
        {
            ViewBag.Categorias = new SelectList(
                _categoriasLN.Obtener(),
                "id",
                "nombre",
                idCategoria
            );

            ViewBag.Marcas = new SelectList(
                _marcasLN.Obtener(),
                "id_Marca",
                "nombre",
                idMarca
            );
        }

        public ActionResult Index(string q, int? idCategoria, int? idMarca, decimal? min, decimal? max)
        {
            CargarCombos(idCategoria, idMarca);

            ViewBag.Q = q;
            ViewBag.Min = min;
            ViewBag.Max = max;

            List<ProductosDTO> lista = _catalogoLN.Obtener(q, idCategoria, idMarca, min, max);
            return View(lista);
        }

        public ActionResult Detalle(int id)
        {
            ProductosDTO producto = new ObtenerProductoPorIdAD().Obtener(id);

            if (producto == null || producto.estado == false)
            {
                return HttpNotFound();
            }

            return View(producto);
        }
    }
}