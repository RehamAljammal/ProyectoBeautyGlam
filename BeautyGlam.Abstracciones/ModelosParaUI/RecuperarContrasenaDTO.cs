using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class RecuperarContrasenaDTO
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress(ErrorMessage = "Correo inválido.")]
        public string correo { get; set; }
    }
}
