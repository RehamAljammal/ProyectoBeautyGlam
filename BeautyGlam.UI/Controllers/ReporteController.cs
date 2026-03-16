using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Devolucion.Reporte;
using BeautyGlam.AccesoADatos.Venta.Reporte;
using BeautyGlam.LogicaDeNegocio.Devolucion.Reporte;
using BeautyGlam.LogicaDeNegocio.Venta.Reporte;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IReporteLN _reporteLN;
        private readonly IReporteDevolucionesLN _ln;
        public ReporteController()
        {
            var contexto = new Contexto();
            IReporteAD reporteAD = new ReporteAD(contexto);
            _reporteLN = new ReporteLN(reporteAD);

            IReporteDevolucionesAD ad = new ReporteDevolucionesAD(contexto);
            _ln = new ReporteDevolucionesLN(ad);
        }

        public ActionResult Ventas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ventas(ReporteFiltroDto filtro)
        {
            var reporte = _reporteLN.GenerarReporteVentas(filtro);
            return View("VentasResultado", reporte);
        }

        public ActionResult ExportarPDF(ReporteFiltroDto filtro)
        {
            var reporte = _reporteLN.GenerarReporteVentas(filtro);
            decimal totalGeneral = reporte.Sum(x => x.Total);

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                string rutaLogo = Server.MapPath("~/Images/logoPNG.png");

                // ===== COLORES PASTEL =====
                BaseColor pastelLavanda = new BaseColor(155, 140, 190);
                BaseColor pastelHeader = new BaseColor(210, 200, 230);
                BaseColor pastelLinea = new BaseColor(180, 165, 210);
                BaseColor grisSuave = new BaseColor(245, 245, 250);
                BaseColor textoOscuro = new BaseColor(80, 70, 100);

                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, pastelLavanda);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, textoOscuro);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, pastelLavanda);

                // ===== HEADER CENTRADO REAL =====
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

                Paragraph titulo = new Paragraph("REPORTE DE VENTAS", tituloFont);
                titulo.Alignment = Element.ALIGN_CENTER;

                PdfPCell celdaTitulo = new PdfPCell(titulo);
                celdaTitulo.Border = PdfPCell.NO_BORDER;
                celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
                tablaHeader.AddCell(celdaTitulo);

                tablaHeader.AddCell(new PdfPCell() { Border = PdfPCell.NO_BORDER });

                doc.Add(tablaHeader);

                // ===== LINEA SUAVE =====
                LineSeparator line = new LineSeparator();
                line.LineColor = pastelLinea;
                line.LineWidth = 1.5f;
                doc.Add(new Chunk(line));
                doc.Add(new Paragraph(" "));

                // ===== TABLA =====
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 2, 4, 2 });

                string[] headers = { "Fecha", "Cliente", "Total" };

                foreach (var h in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                    celda.BackgroundColor = pastelHeader;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.Padding = 8;
                    tabla.AddCell(celda);
                }

                bool alternar = false;

                foreach (var item in reporte)
                {
                    BaseColor fondo = alternar ? grisSuave : BaseColor.WHITE;

                    PdfPCell c1 = new PdfPCell(new Phrase(item.Fecha.ToString("dd/MM/yyyy"), normalFont));
                    PdfPCell c2 = new PdfPCell(new Phrase(item.Cliente, normalFont));
                    PdfPCell c3 = new PdfPCell(new Phrase("₡" + item.Total.ToString("N2"), normalFont));

                    c1.BackgroundColor = fondo;
                    c2.BackgroundColor = fondo;
                    c3.BackgroundColor = fondo;

                    tabla.AddCell(c1);
                    tabla.AddCell(c2);
                    tabla.AddCell(c3);

                    alternar = !alternar;
                }

                doc.Add(tabla);
                doc.Add(new Paragraph(" "));

                Paragraph total = new Paragraph(
                    "TOTAL GENERAL: ₡" + totalGeneral.ToString("N2"),
                    boldFont
                );
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                doc.Close();

                return File(ms.ToArray(),
                    "application/pdf",
                    "ReporteVentas.pdf");
            }
        }


        //REPORTE DE DEVOLUCIONES
        public ActionResult Devoluciones()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Devoluciones(ReporteFiltroDto filtro)
        {
            var reporte = _ln.GenerarReporteDevoluciones(filtro);
            return View("DevolucionesResultado", reporte);
        }


        public ActionResult ExportarPDFDevoluciones(ReporteFiltroDto filtro)
        {
            var reporte = _ln.GenerarReporteDevoluciones(filtro);

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                string rutaLogo = Server.MapPath("~/Images/logoPNG.png");

                // ===== COLORES =====
                BaseColor pastelLavanda = new BaseColor(155, 140, 190);
                BaseColor pastelHeader = new BaseColor(220, 210, 240);
                BaseColor pastelLinea = new BaseColor(190, 175, 220);
                BaseColor grisSuave = new BaseColor(248, 247, 252);
                BaseColor textoOscuro = new BaseColor(85, 75, 110);

                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, pastelLavanda);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, textoOscuro);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

                // ===== HEADER =====
                PdfPTable tablaHeader = new PdfPTable(3);
                tablaHeader.WidthPercentage = 100;
                tablaHeader.SetWidths(new float[] { 1, 2, 1 });

                if (System.IO.File.Exists(rutaLogo))
                {
                    var logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleToFit(90f, 90f);

                    PdfPCell celdaLogo = new PdfPCell(logo);
                    celdaLogo.Border = PdfPCell.NO_BORDER;
                    celdaLogo.HorizontalAlignment = Element.ALIGN_LEFT;
                    tablaHeader.AddCell(celdaLogo);
                }
                else
                {
                    tablaHeader.AddCell(new PdfPCell() { Border = PdfPCell.NO_BORDER });
                }

                Paragraph titulo = new Paragraph("REPORTE DE DEVOLUCIONES", tituloFont);
                titulo.Alignment = Element.ALIGN_CENTER;

                PdfPCell celdaTitulo = new PdfPCell(titulo);
                celdaTitulo.Border = PdfPCell.NO_BORDER;
                celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaTitulo.VerticalAlignment = Element.ALIGN_MIDDLE;
                tablaHeader.AddCell(celdaTitulo);

                tablaHeader.AddCell(new PdfPCell() { Border = PdfPCell.NO_BORDER });

                doc.Add(tablaHeader);

                // ===== LINEA =====
                LineSeparator line = new LineSeparator();
                line.LineColor = pastelLinea;
                line.LineWidth = 1.5f;
                doc.Add(new Chunk(line));

                doc.Add(new Paragraph(" "));

                // ===== TABLA =====
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 3f, 5f, 2f });

                string[] headers = { "Fecha", "Administrador", "Venta" };

                foreach (var h in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                    celda.BackgroundColor = pastelHeader;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    celda.Padding = 8;
                    tabla.AddCell(celda);
                }

                bool alternar = false;

                foreach (var d in reporte)
                {
                    BaseColor fondo = alternar ? grisSuave : BaseColor.WHITE;

                    PdfPCell c1 = new PdfPCell(new Phrase(d.Fecha.ToString("dd/MM/yyyy"), normalFont));
                    c1.BackgroundColor = fondo;
                    c1.HorizontalAlignment = Element.ALIGN_CENTER;
                    c1.Padding = 6;

                    PdfPCell c2 = new PdfPCell(new Phrase(d.Admin ?? "", normalFont));
                    c2.BackgroundColor = fondo;
                    c2.HorizontalAlignment = Element.ALIGN_LEFT;
                    c2.Padding = 6;

                    PdfPCell c3 = new PdfPCell(new Phrase("FAC-" + d.Venta, normalFont));
                    c3.BackgroundColor = fondo;
                    c3.HorizontalAlignment = Element.ALIGN_CENTER;
                    c3.Padding = 6;

                    tabla.AddCell(c1);
                    tabla.AddCell(c2);
                    tabla.AddCell(c3);

                    alternar = !alternar;
                }

                doc.Add(tabla);

                doc.Add(new Paragraph(" "));
                doc.Close();

                return File(ms.ToArray(),
                    "application/pdf",
                    "ReporteDevoluciones.pdf");
            }
        }
    }    
}