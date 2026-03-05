using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("COMENTARIO_BLOG")]
    public class ComentarioBlogAD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Comentario { get; set; }

        [Required]
        public int id_Blog { get; set; }

        [Required]
        public int id_Usuario { get; set; }

        [Required]
        public string comentario { get; set; }

        [Required]
        public DateTime fecha { get; set; } = DateTime.Now;

        [Required]
        public bool estado { get; set; } = true;
        // ===================================
        // Navegación
        // ===================================
        [ForeignKey("id_Blog")]
        public virtual BlogAD Blog { get; set; }

        [ForeignKey("id_Usuario")]
        public virtual UsuarioAD Usuario { get; set; }
    }
}