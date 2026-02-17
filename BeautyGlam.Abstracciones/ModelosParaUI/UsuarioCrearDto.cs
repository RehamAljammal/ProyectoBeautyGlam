using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class UsuarioCrearDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50)]
        public string apellido { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "El username es obligatorio")]
        [StringLength(50)]
        public string username { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [StringLength(200)]
        public string correo { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(20)]
        public string telefono { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(200)]
        public string direccion { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Debe seleccionar un rol")]
        [StringLength(20)]
        public string rol { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
