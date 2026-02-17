using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("PasswordReset")]
    public class PasswordResetAD
    {
        [Key]
        [Column("id_Reset")]
        public int id_Reset { get; set; }

        [Column("id_Usuario")]
        public int id_Usuario { get; set; }

        [Column("tokenHash")]
        public byte[] tokenHash { get; set; }   // VARBINARY(32)

        [Column("fecha_Creacion")]
        public DateTime fecha_Creacion { get; set; }

        [Column("fecha_Expira")]
        public DateTime fecha_Expira { get; set; }

        [Column("usado")]
        public bool usado { get; set; }
    }
}
