using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("BLOG")]
    public class BlogAD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Blog { get; set; }

        [Required]
        [MaxLength(150)]
        public string titulo { get; set; }

        [MaxLength(300)]
        public string resumen { get; set; }

        [Required]
        public string contenido { get; set; }

        [MaxLength(260)]
        public string imagen { get; set; }

        [Required]
        public DateTime fecha_Publicacion { get; set; } = DateTime.Now;

        public DateTime? fecha_Actualizacion { get; set; }

        [Required]
        public bool estado { get; set; } = true;

        // ===================================
        // Navegación
        // ===================================
        public virtual ICollection<ComentarioBlogAD> Comentarios { get; set; } = new List<ComentarioBlogAD>();
    }
}