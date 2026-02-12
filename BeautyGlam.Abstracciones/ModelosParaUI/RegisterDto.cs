using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El username es obligatorio")]
        public string username { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string contrasena { get; set; }

        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [Compare("contrasena", ErrorMessage = "Las contraseñas no coinciden")]
        public string confirmarContrasena { get; set; }
    }
}
