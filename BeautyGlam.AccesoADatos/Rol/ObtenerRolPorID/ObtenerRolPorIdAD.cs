using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Rol.ObtenerRolPorId
{
    public class ObtenerRolPorIdAD
    {
        private Contexto _elContexto;

        public ObtenerRolPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public RolDto ObtenerPorId(int idDelRolABuscar)
        {
            RolDto elRolEnBaseDeDatos =
                (from Rol in _elContexto.Rol
                 where Rol.id_Rol == idDelRolABuscar
                 select new RolDto
                 {
                     id_Rol = Rol.id_Rol,
                     nombre_Rol = Rol.nombre_Rol,
                     estado = Rol.estado
                 }).FirstOrDefault();

            return elRolEnBaseDeDatos;
        }
    }
}
