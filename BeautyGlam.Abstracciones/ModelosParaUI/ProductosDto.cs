using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class ProductosDTO
    {
        public int id { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        // ===== CATEGORÍA =====
        [Display(Name = "ID Categoría")]
        public int idCategoria { get; set; }

        [Display(Name = "Categoría")]
        public string nombreCategoria { get; set; }   

        // ===== MARCA =====
        [Display(Name = "ID Marca")]
        public int idMarca { get; set; }

        [Display(Name = "Marca")]
        public string nombreMarca { get; set; }      

        // ===== PROVEEDOR =====
        [Display(Name = "ID Proveedor")]
        public int idProveedor { get; set; }

        [Display(Name = "Proveedor")]
        public string nombreProveedor { get; set; }   
        

        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}