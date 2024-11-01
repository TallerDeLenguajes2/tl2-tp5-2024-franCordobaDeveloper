using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp5_2024_franCordobaDeveloper.models
{
    public class Productos
    {
        public int idProductos { get; set; }
        public required string Descripcion { get; set; }
        public int Precio { get; set; }
    }
}