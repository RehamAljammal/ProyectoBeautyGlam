using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class PromocionesDTO
    {
        public int id_Promocion { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es obligatorio")]
        public string titulo { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime fecha_Inicio { get; set; }

        [Display(Name = "Fecha de fin")]
        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateTime fecha_Fin { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; } // true = Activa | false = Inactiva
    }
}
