using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("PROMOCION")]
    public class PromocionesAD
    {
        [Key]
        [Column("id_Promocion")]
        public int id_Promocion { get; set; }

        [Column("titulo")]
        public string titulo { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("fecha_Inicio")]
        public DateTime fecha_Inicio { get; set; }

        [Column("fecha_Fin")]
        public DateTime fecha_Fin { get; set; }

        [Column("estado")]
        public bool estado { get; set; }
    }
}
