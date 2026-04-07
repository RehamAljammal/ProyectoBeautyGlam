using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Valoracion_Producto")]
public class ValoracionProductoAD
{
    [Key]
    [Column("id_Valoracion")]
    public int idValoracion { get; set; }

    [Column("id_Usuario")]
    public int idUsuario { get; set; }

    [Column("id_Producto")]
    public int idProducto { get; set; }
    [Column("id")]
    public int id { get; set; }

    [Column("estrellas")]
    public int estrellas { get; set; }

    [Column("comentario")]
    public string comentario { get; set; }

    [Column("fecha")]
    public DateTime fecha { get; set; }
}