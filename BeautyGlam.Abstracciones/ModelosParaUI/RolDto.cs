using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class RolDto
    {
        public int id_Rol { get; set; }

        [Display(Name = "Nombre del Rol")]
        [Required(ErrorMessage = "El nombre del rol es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string nombre_Rol { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
