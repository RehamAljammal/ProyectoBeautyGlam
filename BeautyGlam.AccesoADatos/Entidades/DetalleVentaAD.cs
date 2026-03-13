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

        [Column("id_Producto")]
        public int id_Producto { get; set; }

        [Column("cantidad")]
        public int cantidad { get; set; }

        [Column("precio")]
        public decimal precio { get; set; }

        [ForeignKey("id_Producto")]
        public ProductoAD Producto { get; set; }
    }
}