using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp5_2024_franCordobaDeveloper.models
{
    public class PresupuestosDetalle
    {
        public int IdDetalle { get; set;}
        public required Productos Producto {get; set;}
        public int Cantidad { get; set; }
    }
}