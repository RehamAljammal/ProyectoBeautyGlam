using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Usuario")]
    public class UsuarioAD
    {
        [Key]
        [Column("id_Usuario")]
        public int id_Usuario { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("apellido")]
        public string apellido { get; set; }

        [Column("username")]
        public string username { get; set; }

        [Column("correo")]
        public string correo { get; set; }

        [Column("telefono")]
        public string telefono { get; set; }

        [Column("direccion")]
        public string direccion { get; set; }

        [Column("fecha_Registro")]
        public DateTime fecha_Registro { get; set; }

        [Column("passwordHash")]
        public byte[] passwordHash { get; set; }

        [Column("passwordSalt")]
        public byte[] passwordSalt { get; set; }

        [Column("rol")]
        public string rol { get; set; }  // Admin | Usuario

        [Column("estado")]
        public bool estado { get; set; }
    }
}
