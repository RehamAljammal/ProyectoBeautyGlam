using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("GUIA_REGALO")]
    public class GuiaRegaloAD
    {
        [Key]
        [Column("id_Guia")]
        public int idGuia { get; set; }

        [Column("categoria")]
        public string categoria { get; set; }

        [Column("presupuesto")]
        public decimal presupuesto { get; set; }

        [Column("genero")]
        public string genero { get; set; }

        [Column("tipo")]
        public string tipo { get; set; }

        [Column("estado")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool estado { get; set; }


        public virtual ICollection<GuiaProductoAD> GuiaProducto { get; set; }
    }
}


