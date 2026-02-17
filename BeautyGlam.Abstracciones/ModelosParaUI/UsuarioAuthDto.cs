using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class UsuarioAuthDTO
    {
        public int id_Usuario { get; set; }
        public string correo { get; set; }
        public string rol { get; set; }
        public bool estado { get; set; }

        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
