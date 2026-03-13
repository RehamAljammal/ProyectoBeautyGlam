using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class ModuloDto
    {
        public int id_Modulo { get; set; }

        [Display(Name = "Nombre del Módulo")]
        [Required(ErrorMessage = "El nombre del módulo es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string nombre_Modulo { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}