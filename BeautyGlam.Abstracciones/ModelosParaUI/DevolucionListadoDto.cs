using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class DevolucionListadoDto
    {
        public int id_Devolucion { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public string admin { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
    }
}