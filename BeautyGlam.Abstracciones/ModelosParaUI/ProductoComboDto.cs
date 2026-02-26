using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    [Table("PROMOCION_PRODUCTO")]
    public class ProductoComboDTO
    {
        [Key]
        [Column("id")]
        public int id_Producto { get; set; }
        [Column("nombre")]
        public string nombre { get; set; }
        [Column("precio")]
        public decimal precio { get; set; }


    }
}
