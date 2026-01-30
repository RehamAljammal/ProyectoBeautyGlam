using BeautyGlam.Abstracciones.AccesoADatos.Inventario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Inventario
{
    public class RegistrarInventarioAD : IRegistrarInventarioAD
    {
        private readonly Contexto _elContexto;

        public RegistrarInventarioAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public async Task Registrar(InventarioDto inventario)
        {
            InventarioAD entidad = new InventarioAD
            {
                id = inventario.id,             
                stockActual = 0,
                stockMinimo = 0,
                stockMaximo = 0
            };

            _elContexto.Inventario.Add(entidad);
            await _elContexto.SaveChangesAsync();

            inventario.idInventario = entidad.idInventario;
        }

    }
}
