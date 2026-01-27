using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Producto")]
    public class ProductoAD
    {
        [Key]
        [Column("id")]
        public int id{ get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("precio")]
        public decimal precio { get; set; }

        [Column("imagen")]
        public string imagen { get; set; }

        [Column("id_Categoria")]
        public int idCategoria { get; set; }

        [Column("id_Marca")]
        public int idMarca { get; set; }

        [Column("id_Proveedor")]
        public int idProveedor { get; set; }

        [Column("estado")]
        public bool estado { get; set; } // true = Activo | false = Inactivo
    }
}