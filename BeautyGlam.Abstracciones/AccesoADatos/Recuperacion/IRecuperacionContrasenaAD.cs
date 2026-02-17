using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Recuperacion
{
    public interface IRecuperacionContrasenaAD
    {
        Task<int> CrearToken(int idUsuario, byte[] tokenHash, DateTime fechaExpira);

        Task<ResetVigenteDTO> ObtenerResetVigentePorTokenHash(byte[] tokenHash);

        Task<int> MarcarComoUsado(int idReset);
    }
}
