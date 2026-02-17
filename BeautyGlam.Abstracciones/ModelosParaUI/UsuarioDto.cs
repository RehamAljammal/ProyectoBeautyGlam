using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class UsuarioDto
    {
        public int id_Usuario { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string apellido { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "El username es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
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

        [Display(Name = "Fecha de Registro")]
        public DateTime fecha_Registro { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Debe seleccionar un rol")]
        [StringLength(20)]
        public string rol { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}
