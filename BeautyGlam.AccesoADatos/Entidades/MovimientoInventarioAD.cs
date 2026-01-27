using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Movimiento_Inventario")]

    public class MovimientoInventarioAD
    {
        [Key]
        [Column("id_Movimiento")]
        public int idMovimiento { get; set; }

        [Column("tipo_Movimiento")]
        public string tipoMovimiento { get; set; }

        [Column("cantidad")]
        public int cantidad { get; set; }

        [Column("fecha_Movimiento")]
        public DateTime fechaMovimiento { get; set; }

        [Column("observacion")]
        public string observacion { get; set; }

        [Column("id")]
        public int idProducto { get; set; }


    }
}