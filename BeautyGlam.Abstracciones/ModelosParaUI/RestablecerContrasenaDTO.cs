using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class RestablecerContrasenaDTO
    {
        [Display(Name = "Token")]
        [Required(ErrorMessage = "Token requerido.")]
        public string token { get; set; }

        [Display(Name = "Nueva Contraseña")]
        [Required(ErrorMessage = "La nueva contraseña es requerida.")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres.")]
        public string nuevaContrasena { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "Confirma la contraseña.")]
        [Compare("nuevaContrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        public string confirmarContrasena { get; set; }
    }
}
