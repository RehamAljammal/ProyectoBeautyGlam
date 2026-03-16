using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Factura")]
    public class FacturaAD
    {
        [Key]
        [Column("id_Factura")]
        public int id_Factura { get; set; }

        [Column("id_Venta")]
        public int id_Venta { get; set; }

        [Column("numero_Factura")]
        public string numero_Factura { get; set; }

        [Column("fecha_Emision")]
        public DateTime fecha_Emision { get; set; }

        [ForeignKey("id_Venta")]
        public VentaAD Venta { get; set; }
    }
}