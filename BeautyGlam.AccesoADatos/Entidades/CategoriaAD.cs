using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("CATEGORIA")]
    public class CategoriaAD
    {
        [Column("ID_CATEGORIA")]
        public int id { get; set; }

        [Column("NOMBRE_CAT")]
        public string nombre { get; set; }

        [Column("DESCRIPCION")]
        public string descripcion { get; set; }

        [Column("ESTADO")]
        public bool estado { get; set; }
    }
}
