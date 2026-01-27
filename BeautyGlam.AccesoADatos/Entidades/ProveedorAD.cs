using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("PROVEEDOR")]
    public class ProveedorAD
    {

        [Column("ID")]
        public int id { get; set; }

        [Column("NOMBRE")]
        public string nombre { get; set; }

        [Column("CEDULA")]
        public int cedula { get; set; }

        [Column("DIRECCION")]
        public string direccion { get; set; }

        [Column("CORREO")]
        public string correo { get; set; }

        [Column("TELEFONO")]
        public string telefono { get; set; }

        [Column("ESTADO")]
        public bool estado { get; set; }
    }

}
