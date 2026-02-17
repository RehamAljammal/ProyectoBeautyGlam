using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Proveedores.RegistrarProveedor
{
    public interface IRegistrarProveedorAD
    {
        Task<int> Registrar(ProveedoresDto elProveedorParaGuardar);

    }
}
