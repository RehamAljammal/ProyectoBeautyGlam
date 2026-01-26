using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class MarcaDto
    {
        public int id_Marca { get; set; }

        [Display(Name = "Nombre de la marca")]

        public string nombre { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

    }
}
