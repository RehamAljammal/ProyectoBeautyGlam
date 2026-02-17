using BeautyGlam.Abstracciones.AccesoADatos.Recuperacion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Recuperacion
{
    public class RecuperacionContrasenaAD : IRecuperacionContrasenaAD
    {
        private readonly Contexto _elContexto;

        public RecuperacionContrasenaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> CrearToken(int idUsuario, byte[] tokenHash, DateTime fechaExpira)
        {
            if (tokenHash == null) throw new ArgumentNullException("tokenHash");

            PasswordResetAD reset = new PasswordResetAD();
            reset.id_Usuario = idUsuario;
            reset.tokenHash = tokenHash;
            reset.fecha_Creacion = DateTime.Now;
            reset.fecha_Expira = fechaExpira;
            reset.usado = false;

            _elContexto.PasswordReset.Add(reset);
            int filas = await _elContexto.SaveChangesAsync();
            return filas;
        }

        public async Task<ResetVigenteDTO> ObtenerResetVigentePorTokenHash(byte[] tokenHash)
        {
            if (tokenHash == null) return null;

            DateTime ahora = DateTime.Now;

            PasswordResetAD reset = await _elContexto.PasswordReset
                .FirstOrDefaultAsync(x =>
                    x.usado == false &&
                    x.fecha_Expira > ahora &&
                    x.tokenHash == tokenHash
                );

            if (reset == null) return null;

            ResetVigenteDTO dto = new ResetVigenteDTO();
            dto.id_Reset = reset.id_Reset;
            dto.id_Usuario = reset.id_Usuario;
            dto.fecha_Expira = reset.fecha_Expira;
            dto.usado = reset.usado;

            return dto;
        }

        public async Task<int> MarcarComoUsado(int idReset)
        {
            PasswordResetAD reset = await _elContexto.PasswordReset.FindAsync(idReset);

            if (reset == null) return 0;

            reset.usado = true;
            int filas = await _elContexto.SaveChangesAsync();
            return filas;
        }
    }
}
