using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("TONO")]
    public class TonoAD
    {
        [Key]
        public int id_Tono { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public bool estado { get; set; }
    }
}