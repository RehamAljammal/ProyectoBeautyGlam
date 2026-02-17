using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("GUIA_PRODUCTO")]
    public class GuiaProductoAD
    {
        [Key]
        [Column("id_Guia", Order = 0)]
        public int id_Guia { get; set; }

        [Key]
        [Column("id", Order = 1)]
        public int id { get; set; }

        // 🔗 Navegaciones
        public virtual GuiaRegaloAD GuiaRegalo { get; set; }
        public virtual ProductoAD Producto { get; set; }
    }
}

