using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Pago")]
    public class PagoAD
    {
        [Key]
        [Column("id_Pago")]
        public int id_Pago { get; set; }

        [Column("id_Venta")]
        public int id_Venta { get; set; }

        [Column("metodo_Pago")]
        public string metodo_Pago { get; set; }

        [Column("monto")]
        public decimal monto { get; set; }

        [Column("fecha_Pago")]
        public DateTime fecha_Pago { get; set; }

        [ForeignKey("id_Venta")]
        public VentaAD Venta { get; set; }
        [Column("estado")]
        public string estado { get; set; }
    }
}