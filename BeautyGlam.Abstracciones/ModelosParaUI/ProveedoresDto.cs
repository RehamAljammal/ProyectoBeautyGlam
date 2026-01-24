using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class ProveedoresDto
    {
        public int id { get; set; }

        [Display(Name = "Nombre del Proveedor")]
        public string nombre { get; set; }

        [Display(Name = "Cédula")]
        public int cedula { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string correo { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; } // true = Activo | false = Inactivo
    }
}
