using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class UsuarioDto
    {
        public int id_Usuario { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]

        public string apellido { get; set; }

        [Display(Name = "Username")]
        public string username { get; set; }

        [Display(Name = "Telefono")]

        public string telefono { get; set; }

        [Display(Name = "Direccion")]

        public string direccion { get; set; }

        [Display(Name = "Fecha De Registro")]

        public DateTime fechaRegistro { get; set; }

        [Display(Name = "Correo")]

        public string correo { get; set; }

        public string AspNetUserId { get; set; }

        [Display(Name = "Estado")]

        public bool estado { get; set; }
    }
}
