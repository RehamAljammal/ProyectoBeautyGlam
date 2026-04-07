using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    
        public class HistorialCompraDto
        {
            public int idVenta { get; set; }
            public DateTime fecha { get; set; }
            public decimal total { get; set; }
            public string estado { get; set; }
        }

        public class DetalleCompraDto
        {
            public int idProducto { get; set; }
            public string nombre { get; set; }
            public int cantidad { get; set; }
            public decimal precio { get; set; }
            public string imagen { get; set; }
        }

        public class ValoracionDto
        {
            public int idUsuario { get; set; }
            public int idProducto { get; set; }
            public int idVenta { get; set; }
             public int id { get; set; }
            public int estrellas { get; set; }
            public string comentario { get; set; }
            public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }

    }

    public class ReclamoDto
        {
            public int idVenta { get; set; }
            public int idProducto { get; set; }
            public string descripcion { get; set; }
        }
    }

