using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Detalle_Venta")]
    public class DetalleVentaAD
    {
        [Key]
        [Column("id_Detalle")]
        public int id_Detalle { get; set; }

        [Column("id_Venta")]
        public int id_Venta { get; set; }

        [Column("id")]
        public int id { get; set; }

        [Column("cantidad")]
        public int cantidad { get; set; }

        [Column("precio_Unitario")]
        public decimal precio_Unitario { get; set; }

        [Column("subtotal")]
        public decimal subtotal { get; set; }

        [ForeignKey("id_Venta")]
        public VentaAD Venta { get; set; }

        [ForeignKey("id")]
        public ProductoAD Producto { get; set; }
    }
}