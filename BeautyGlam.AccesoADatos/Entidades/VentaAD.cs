using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Venta")]
    public class VentaAD
    {
        [Key]
        [Column("id_Venta")]
        public int id_Venta { get; set; }

        [Column("id_Usuario")]
        public int id_Usuario { get; set; }

        [Column("fecha_Venta")]
        public DateTime fecha_Venta { get; set; }

        [Column("total")]
        public decimal total { get; set; }

        [Column("metodo_Pago")]
        public string metodo_Pago { get; set; }  // Efectivo | SINPE | Transferencia

        [Column("estado")]
        public string estado { get; set; }  // Pagada | Pendiente | Entregada

        [ForeignKey("id_Usuario")]
        public UsuarioAD Usuario { get; set; }

        public virtual ICollection<PagoAD> Pago { get; set; }
        public virtual ICollection<FacturaAD> Factura { get; set; }
        public virtual ICollection<DetalleVentaAD> Detalle_Venta { get; set; }
    }
}