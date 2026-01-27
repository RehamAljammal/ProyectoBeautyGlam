using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Proveedores.DetallesDeProveedor
{
    public interface IDetallesProveedorLN
    {
        Task<int> Detalles(ProveedoresDto elProveedorParaGuardar);


    }
}
