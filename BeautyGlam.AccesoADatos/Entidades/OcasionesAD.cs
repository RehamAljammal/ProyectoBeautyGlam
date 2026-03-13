using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("OCASIONES")]
    public class OcasionAD
    {
        [Key]
        [Column("id_Ocasion")]
        public int idOcasion { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("estado")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool estado { get; set; }

        public virtual ICollection<GuiaRegaloAD> GuiasRegalo { get; set; }
    }
}