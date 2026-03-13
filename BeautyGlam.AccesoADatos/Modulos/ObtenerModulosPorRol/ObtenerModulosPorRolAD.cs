using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Entidades;
using System.Collections.Generic;
using System.Linq;

public class ObtenerModulosPorRolAD
{
    private readonly Contexto _contexto;

    public ObtenerModulosPorRolAD()
    {
        _contexto = new Contexto();
    }

    public List<ModuloDto> Obtener(int idRol)
    {
        List<ModuloDto> lista = (from m in _contexto.Modulo
                                 join rm in _contexto.RolModulo
                                 on m.id_Modulo equals rm.id_Modulo
                                 where rm.id_Rol == idRol
                                 select new ModuloDto
                                 {
                                     id_Modulo = m.id_Modulo,
                                     nombre_Modulo = m.nombre_Modulo,
                                     estado = m.estado
                                 }).ToList();

        return lista;
    }
}