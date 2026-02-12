using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class LoginDTO
    {
        [Required]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }
    }
}
