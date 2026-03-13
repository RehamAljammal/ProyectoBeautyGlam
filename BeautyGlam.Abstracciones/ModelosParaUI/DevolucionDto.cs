using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class DevolucionDto
    {
        public int id_Devolucion { get; set; }
        public int id_Producto { get; set; }
        public int id_Usuario { get; set; }   
        public int id_Venta { get; set; }  

        public int cantidad { get; set; }
        public string motivo { get; set; }
        public DateTime fecha_Devolucion { get; set; }
        public int id_Admin { get; set; }
        public string observacion { get; set; }
        public string estado { get; set; }


    }
}