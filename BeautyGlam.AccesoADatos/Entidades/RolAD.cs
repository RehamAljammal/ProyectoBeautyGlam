using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Rol")]
    public class RolAD
    {
        [Key]
        [Column("id_Rol")]
        public int id_Rol { get; set; }

        [Column("nombre_Rol")]
        public string nombre_Rol { get; set; }

        [Column("estado")]
        public bool estado { get; set; }
    }
}

