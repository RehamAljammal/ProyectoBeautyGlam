using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class CategoriasDto
    {
        public int id { get; set; }

        [Display(Name = "Nombre de la Categoría")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; } // true = Activa | false = Inactiva
    }
}
