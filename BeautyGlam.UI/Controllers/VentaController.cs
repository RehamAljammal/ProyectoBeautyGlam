using BeautyGlam.Abstracciones.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.Abstracciones.AccesoADatos.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.AccesoADatos.Venta;
using BeautyGlam.Abstracciones.AccesoDatos;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.ListaProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.LogicaNegocio;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.AccesoADatos.Usuario.ListaUsuario;
using BeautyGlam.AccesoADatos.Venta;
using BeautyGlam.LogicaDeNegocio.Productos.ListaProductos;
using BeautyGlam.LogicaDeNegocio.Usuario.ListaUsuario;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class VentaController : Controller
    {
        private readonly IRegistrarVentaLN _registrarVentaLN;
        private readonly IObtenerLaListaDeUsuariosLN _obtenerUsuariosLN;
        private readonly IObtenerLaListadeProductosLN _obtenerProductosLN;
        private readonly IVentaLN _obtenerListaVentasLN;



        public VentaController()
        {
            var contexto = new Contexto();

            IRegistrarVentaAD registrarVentaAD = new RegistrarVentaAD(contexto);
            IObtenerListaDeUsuariosAD usuariosAD = new ObtenerListaDeUsuariosAD();
            IObtenerListaDeProductosAD productosAD = new ObtenerLaListaDeProductosAD();
            IVentaAD obtenerListaVentasAD = new ListaVentaAD(contexto);

            IRegistrarMovimientoInventarioLN movimientoLN =
                new RegistrarMovimientoInventarioLN();

            _registrarVentaLN = new RegistrarVentaLN(
                registrarVentaAD,
                usuariosAD,
                productosAD,
                movimientoLN);  

            _obtenerUsuariosLN = new ObtenerLaListaDeUsuariosLN();
            _obtenerProductosLN = new ObtenerLaListaDeProductosLN();

            _obtenerListaVentasLN = new ListadoVentaLN(obtenerListaVentasAD);
        }

        public ActionResult Listado(DateTime? fechaInicio, DateTime? fechaFin, int pagina = 1)
        {
            int registrosPorPagina = 10;

            var ventas = _obtenerListaVentasLN.ObtenerVentas();

            // FILTRO POR FECHA
            if (fechaInicio.HasValue)
            {
                ventas = ventas
                    .Where(v => v.fecha_Venta.Date >= fechaInicio.Value.Date)
                    .ToList();
            }

            if (fechaFin.HasValue)
            {
                ventas = ventas
                    .Where(v => v.fecha_Venta.Date <= fechaFin.Value.Date)
                    .ToList();
            }

            // ORDENAR DE MAS NUEVA A MAS VIEJA
            ventas = ventas
                .OrderByDescending(v => v.fecha_Venta)
                .ToList();

            int totalRegistros = ventas.Count();

            var ventasPaginadas = ventas
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);

            ViewBag.FechaInicio = fechaInicio;
            ViewBag.FechaFin = fechaFin;

            return View(ventasPaginadas);
        }

        public ActionResult Registrar()
        {
            CargarCombos();
            return View(new VentaDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrar(VentaDto modelo)
        {
            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                throw new Exception("Modelo inválido: " + string.Join(" | ", errores));
            }

            try
            {
                int idVenta = await _registrarVentaLN.Registrar(modelo);

                TempData["MensajeExito"] = "Venta registrada correctamente.";
                return RedirectToAction("Factura", new { id = idVenta });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                CargarCombos();
                return View(modelo);
            }
        }

        // ================== FACTURA ==================
        public ActionResult Factura(int id)
        {
            var factura = _obtenerListaVentasLN.ObtenerVentaPorId(id);

            if (factura == null)
                return HttpNotFound();

            return View(factura);
        }

        public ActionResult DescargarPDF(int id)
        {
            var factura = _obtenerListaVentasLN.ObtenerVentaPorId(id);

            if (factura == null)
                return HttpNotFound();

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                string rutaLogo = Server.MapPath("~/Images/logoPNG.png");

                BaseColor pastelLavanda = new BaseColor(155, 140, 190);
                BaseColor pastelHeader = new BaseColor(220, 210, 240);
                BaseColor pastelLinea = new BaseColor(190, 175, 220);
                BaseColor grisSuave = new BaseColor(248, 247, 252);
                BaseColor textoOscuro = new BaseColor(85, 75, 110);

                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, pastelLavanda);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, textoOscuro);

                PdfPTable tablaHeader = new PdfPTable(3);
                tablaHeader.WidthPercentage = 100;
                tablaHeader.SetWidths(new float[] { 1, 2, 1 });

                if (System.IO.File.Exists(rutaLogo))
                {
                    var logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleToFit(100f, 100f);

                    PdfPCell celdaLogo = new PdfPCell(logo);
                    celdaLogo.Border = PdfPCell.NO_BORDER;
                    tablaHeader.AddCell(celdaLogo);
                }
                else
                {
                    tablaHeader.AddCell(new PdfPCell() { Border = PdfPCell.NO_BORDER });
                }

                Paragraph titulo = new Paragraph("FACTURA", tituloFont);
                titulo.Alignment = Element.ALIGN_CENTER;

                PdfPCell celdaTitulo = new PdfPCell(titulo);
                celdaTitulo.Border = PdfPCell.NO_BORDER;
                celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
                tablaHeader.AddCell(celdaTitulo);

                tablaHeader.AddCell(new PdfPCell() { Border = PdfPCell.NO_BORDER });

                doc.Add(tablaHeader);

                LineSeparator line = new LineSeparator();
                line.LineColor = pastelLinea;
                line.LineWidth = 1.5f;
                doc.Add(new Chunk(line));
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph("Número: " + factura.numeroFactura, boldFont));
                doc.Add(new Paragraph("Cliente: " + factura.cliente, normalFont));
                doc.Add(new Paragraph("Fecha: " + factura.fecha.ToString("dd/MM/yyyy"), normalFont));
                doc.Add(new Paragraph("Método de Pago: " + factura.metodoPago, normalFont));
                doc.Add(new Paragraph(" "));

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 3, 1, 1.5f, 1.5f });

                string[] headers = { "Producto", "Cantidad", "Precio", "Subtotal" };

                foreach (var h in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                    celda.BackgroundColor = pastelHeader;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.Padding = 8;
                    tabla.AddCell(celda);
                }

                bool alternar = false;

                foreach (var item in factura.Detalles)
                {
                    BaseColor fondo = alternar ? grisSuave : BaseColor.WHITE;

                    PdfPCell c1 = new PdfPCell(new Phrase(item.producto, normalFont));
                    PdfPCell c2 = new PdfPCell(new Phrase(item.cantidad.ToString(), normalFont));
                    PdfPCell c3 = new PdfPCell(new Phrase("₡" + item.precio.ToString("N2"), normalFont));
                    PdfPCell c4 = new PdfPCell(new Phrase("₡" + item.subtotal.ToString("N2"), normalFont));

                    c1.BackgroundColor = fondo;
                    c2.BackgroundColor = fondo;
                    c3.BackgroundColor = fondo;
                    c4.BackgroundColor = fondo;

                    tabla.AddCell(c1);
                    tabla.AddCell(c2);
                    tabla.AddCell(c3);
                    tabla.AddCell(c4);

                    alternar = !alternar;
                }

                doc.Add(tabla);
                doc.Add(new Paragraph(" "));

                Paragraph total = new Paragraph(
                    "TOTAL: ₡" + factura.total.ToString("N2"),
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, pastelLavanda)
                );
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                doc.Close();

                return File(ms.ToArray(),
                    "application/pdf",
                    "Factura_" + factura.numeroFactura + ".pdf");
            }
        }

        private void CargarCombos()
        {
            var clientes = _registrarVentaLN.ObtenerClientesActivos();
            var productos = _registrarVentaLN.ObtenerProductosActivos();

            ViewBag.Clientes = new SelectList(clientes, "id_Usuario", "nombre");
            ViewBag.Productos = productos;
        }
    }
}
