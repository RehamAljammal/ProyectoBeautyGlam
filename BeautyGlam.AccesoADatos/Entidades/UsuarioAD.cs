using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Usuario")]

    public class UsuarioAD
    {
        [Column("ID_USUARIO")]
        public int idUsuario { get; set; }

        [Column("NOMBRE")]
        public string nombre { get; set; }

        [Column("APELLIDO")]
        public string apellido { get; set; }

        [Column("USERNAME")]
        public string username { get; set; }

        [Column("CORREO")]
        public string correo { get; set; }

        [Column("TELEFONO")]
        public string telefono { get; set; }

        [Column("DIRECCION")]
        public string direccion { get; set; }

        [Column("FECHA_REGISTRO")]
        public DateTime fechaRegistro { get; set; }

        [Column("ASPNETUSERID")]
        public string AspNetUserId { get; set; }

        [Column("ESTADO")]
        public bool estado { get; set; }


    }
}
