using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EliminarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia;
using BeautyGlam.LogicaDeNegocio;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo.EliminarGuiaRegalo;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class GuiaRegalosController : Controller
    {
        private readonly ObtenerGuiaRegaloLN _obtenerListaGuiaRegaloLN;
        private readonly IRegistrarGuiaRegaloLN _registrarGuiaRegaloLN;
        private readonly ObtenerProductosParaGuiaLN _obtenerProductosLN;
        private readonly IObtenerProductosParaGuiaAD _obtenerProductosAD;
        private readonly IEditarGuiaRegaloLN _editarGuiaRegaloLN;
        private readonly IEliminarGuiaRegaloLN _eliminarGuiaRegaloLN;

        public GuiaRegalosController()
        {
            _obtenerListaGuiaRegaloLN = new ObtenerGuiaRegaloLN();
            _registrarGuiaRegaloLN = new RegistrarGuiaRegaloLN();

            _obtenerProductosAD = new ObtenerProductosParaGuiaAD();
            _obtenerProductosLN = new ObtenerProductosParaGuiaLN(_obtenerProductosAD);
            IEditarGuiaRegaloAD editarAD = new EditarGuiaRegaloAD();
            _editarGuiaRegaloLN = new EditarGuiaRegaloLN(editarAD);
            _eliminarGuiaRegaloLN = new EliminarGuiaRegaloLN();

        }

        public ActionResult Index(string categoria, int? presupuesto, string genero, string tipo)
        {
            var lista = _obtenerListaGuiaRegaloLN.Obtener()
                .Where(x => x.estado) 
                .ToList();

            if (!string.IsNullOrEmpty(categoria))
                lista = lista.Where(x => x.categoria == categoria).ToList();

            if (presupuesto.HasValue)
                lista = lista.Where(x => x.presupuesto == presupuesto.Value).ToList();

            if (!string.IsNullOrEmpty(genero))
                lista = lista.Where(x => x.genero == genero).ToList();

            if (!string.IsNullOrEmpty(tipo))
                lista = lista.Where(x => x.tipo == tipo).ToList();

            ViewBag.categoria = categoria;
            ViewBag.presupuesto = presupuesto;
            ViewBag.genero = genero;
            ViewBag.tipo = tipo;

            return View(lista);
        }

        public ActionResult Filtrar(string categoria, string presupuesto, string genero, string tipo)
        {
            var lista = _obtenerListaGuiaRegaloLN.Obtener()
                .Where(x => x.estado == true); 

            if (!string.IsNullOrEmpty(categoria))
                lista = lista.Where(x => x.categoria == categoria);

            if (!string.IsNullOrEmpty(presupuesto))
            {
                if (presupuesto == "1") lista = lista.Where(x => x.presupuesto < 5000);
                if (presupuesto == "2") lista = lista.Where(x => x.presupuesto >= 10000 && x.presupuesto <= 15000);
                if (presupuesto == "3") lista = lista.Where(x => x.presupuesto > 20000);
            }

            if (!string.IsNullOrEmpty(genero))
                lista = lista.Where(x => x.genero == genero);

            if (!string.IsNullOrEmpty(tipo))
                lista = lista.Where(x => x.tipo == tipo);

            return PartialView("_TablaGuias", lista.ToList());
        }



        public async Task<ActionResult> RegistrarRegalo()
        {
            GuiaRegaloDto modelo = new GuiaRegaloDto
            {
                productosDisponibles = await _obtenerProductosLN.Obtener(),
                productosSeleccionados = new List<int>()
            };

            return View(modelo);
        }


        [HttpPost]
        public async Task<ActionResult> RegistrarRegalo(GuiaRegaloDto elRegaloParaGuardar)
        {
            if (!ModelState.IsValid)
            {
                elRegaloParaGuardar.productosDisponibles =
                    await _obtenerProductosLN.Obtener();

                return View(elRegaloParaGuardar);
            }

            elRegaloParaGuardar.estado = true;

            await _registrarGuiaRegaloLN.Registrar(elRegaloParaGuardar);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Editar(int id)
        {
            List<GuiaRegaloDto> guias =
                _obtenerListaGuiaRegaloLN.Obtener();

            GuiaRegaloDto guia =
                guias.FirstOrDefault(g => g.idGuia == id);

            if (guia == null)
                return HttpNotFound();

            List<ProductoSeleccionadoDto> productos =
                await _obtenerProductosLN.Obtener();

            guia.productosDisponibles = productos;

            if (guia.productosSeleccionados == null)
                guia.productosSeleccionados = new List<int>();

            return View(guia);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(GuiaRegaloDto modelo)
        {
            if (!ModelState.IsValid)
            {
                List<ProductoSeleccionadoDto> productos =
                    await _obtenerProductosLN.Obtener();

                modelo.productosDisponibles = productos;

                return View(modelo);
            }

            await _editarGuiaRegaloLN.Editar(modelo);

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            var lista = _obtenerListaGuiaRegaloLN.Obtener();

            GuiaRegaloDto guia = lista.FirstOrDefault(g => g.idGuia == id);

            if (guia == null)
                return RedirectToAction("Index");

            return View(guia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(GuiaRegaloDto laGuiaParaEliminar)
        {
            try
            {
                await _eliminarGuiaRegaloLN.Eliminar(laGuiaParaEliminar);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(laGuiaParaEliminar);
            }
        }

        public async Task<ActionResult> Detalle(int id)
        {
            GuiaRegaloDto guia = _obtenerListaGuiaRegaloLN
                .Obtener()
                .FirstOrDefault(g => g.idGuia == id);

            if (guia == null)
                return HttpNotFound();

            List<ProductoSeleccionadoDto> productos = await _obtenerProductosLN.Obtener();

            guia.productosDisponibles = productos
                .Where(p => guia.productosSeleccionados.Contains(p.id))
                .ToList();

            return View(guia);
        }


    }
}
