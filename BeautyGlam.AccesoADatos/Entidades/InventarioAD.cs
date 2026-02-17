using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Inventario")]

    public class InventarioAD
    {
        [Key]
        [Column("id_Inventario")]
        public int idInventario { get; set; }

        [Column("stock_Actual")]
        public int stockActual { get; set; }

        [Column("stock_Minimo")]
        public int stockMinimo { get; set; }

        [Column("stock_Maximo")]
        public int stockMaximo { get; set; }

        [Column("id")]
        public int id { get; set; }

        public virtual ProductoAD Producto { get; set; }

    }
}
