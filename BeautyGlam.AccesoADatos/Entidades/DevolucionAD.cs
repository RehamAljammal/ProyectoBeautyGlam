using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Devolucion")]
    public class DevolucionAD
    {
        [Key]
        [Column("id_Devolucion")]
        public int id_Devolucion { get; set; }

        [Column("motivo")]
        public string motivo { get; set; }

        [Column("fecha_Devolucion")]
        public DateTime fecha_Devolucion { get; set; }

        [Column("id_Admin")]
        public int id_Admin { get; set; }

        [Column("observacion")]
        public string observacion { get; set; }

        [Column("estado")]
        public string estado { get; set; }


        [ForeignKey("id_Admin")]
        public UsuarioAD Admin { get; set; }

        [Column("id_Venta")]
        public int? id_Venta { get; set; }

        [ForeignKey("id_Venta")]
        public VentaAD Venta { get; set; }
    }
}
