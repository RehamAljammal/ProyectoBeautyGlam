using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Recuperacion
{
    public interface IRecuperacionContrasenaLN
    {
        Task<string> SolicitarToken(string correo, string urlBase);
        Task<string> Restablecer(string token, string nuevaContrasena);
    }
}
