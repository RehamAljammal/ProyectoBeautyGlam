using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("RolModulo")]
    public class RolModuloAD
    {
        [Key]
        public int id_RolModulo { get; set; }

        public int id_Rol { get; set; }

        public int id_Modulo { get; set; }
    }
}