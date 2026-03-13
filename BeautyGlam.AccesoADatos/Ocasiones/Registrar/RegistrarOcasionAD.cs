using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Registrar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Ocasiones.Registrar
{
    public class RegistrarOcasionAD : IRegistrarOcasionAD
    {
        private Contexto _contexto;

        public RegistrarOcasionAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> Registrar(OcasionDto dto)
        {
            OcasionAD ocasion = new OcasionAD
            {
                nombre = dto.nombre,
                estado = dto.estado
            };

            _contexto.Ocasiones.Add(ocasion);

            return await _contexto.SaveChangesAsync();
        }
    }
}