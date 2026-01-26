using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Marca")]

    public class MarcaAD
    {
        [Column("ID_MARCA")]
        public int id_Marca { get; set; }

        [Column("NOMBRE")]
        public string nombre { get; set; }

        [Column("ESTADO")]
        public bool estado { get; set; }
    }
}
