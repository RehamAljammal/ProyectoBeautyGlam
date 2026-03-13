using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Modulo")]
    public class ModuloAD
    {
        [Key]
        public int id_Modulo { get; set; }

        public string nombre_Modulo { get; set; }

        public bool estado { get; set; }
    }
}