using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class RespuestasSkincareDTO
    {
        public string tipoPiel { get; set; }
        public string frecuencia { get; set; }
        public string sensibilidad { get; set; }

        public List<string> problema { get; set; }
        public List<string> objetivo { get; set; }
    }
}