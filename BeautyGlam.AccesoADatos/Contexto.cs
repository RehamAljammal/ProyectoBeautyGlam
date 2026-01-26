using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public DbSet<ProveedorAD> Proveedor { get; set; }
        public DbSet<CategoriaAD> Categoria { get; set; }
        public DbSet<MarcaAD> Marca { get; set; }


    }
}
