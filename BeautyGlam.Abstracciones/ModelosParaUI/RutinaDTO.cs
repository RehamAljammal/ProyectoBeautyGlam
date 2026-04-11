using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class RutinaDTO
    {
        public ProductosDTO Limpieza { get; set; }
        public ProductosDTO Tonico { get; set; }
        public ProductosDTO Hidratante { get; set; }
        public ProductosDTO ProtectorSolar { get; set; }

        public ProductosDTO Serum { get; set; }
    }
}